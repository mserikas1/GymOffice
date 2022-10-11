﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using GymOffice.Common.DTOs;
using GymOffice.WebAdmin.ViewModels;

namespace GymOffice.WebAdmin.Areas.Identity.Pages.Account
{
    /// <summary>
    ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
    ///     directly from your code. This API may change or be removed in future releases.
    /// </summary>
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmployeeDataProvider _employeeDataProvider;
        private readonly IEditReceptionistCommand _editReceptionistCommand;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<IdentityUser> signInManager, ILogger<LoginModel> logger, RoleManager<IdentityRole> roleManager,
            IEmployeeDataProvider employeeDataProvider, IEditReceptionistCommand editReceptionistCommand)
        {
            _signInManager = signInManager;
            _logger = logger;
            _roleManager = roleManager;
            _employeeDataProvider = employeeDataProvider;
            _editReceptionistCommand = editReceptionistCommand;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            // this should be called only once to create Roles where we have RoleManager (for example, in RegisterModel)
            // _roleManager.CreateAsync(new IdentityRole("Admin"); // { Name = "Admin", NormalizedName = "ADMIN" });
            // _roleManager.CreateAsync(new IdentityRole("Visitor"); // { Name = "Visitor", NormalizedName = "VISITOR" });
            // _roleManager.CreateAsync(new IdentityRole("Receptionist"); // { Name = "Receptionist", NormalizedName = "RECEPTIONIST" });
            // _roleManager.CreateAsync(new IdentityRole("Coach"); // { Name = "Coach", NormalizedName = "COACH" });

            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    IdentityUser user = await _signInManager.UserManager.FindByEmailAsync(Input.Email);
                    IList<string> roles = await _signInManager.UserManager.GetRolesAsync(user);
                    string role = (roles != null && roles.Count > 0) ? roles[0] : "Undefined";
                    _logger.LogWarning($"User {Input.Email} (role: {role}) logged in.");

                    if (role == "Receptionist")
                    {
                        Receptionist receptionist = await _employeeDataProvider.GetReceptionistByIdAsync(Guid.Parse(user.Id));
                        if (receptionist != null)
                        {
                            receptionist.IsAtWork = true;
                            await _editReceptionistCommand.ExecuteAsync(receptionist);
                        }
                    }

                    return LocalRedirect("/"+role.ToLower());
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}

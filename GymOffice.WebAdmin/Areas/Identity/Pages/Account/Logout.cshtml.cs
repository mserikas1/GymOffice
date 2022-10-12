// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GymOffice.WebAdmin.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly IEmployeeDataProvider _employeeDataProvider;
        private readonly IEditReceptionistCommand _editReceptionistCommand;
        
        public LogoutModel(SignInManager<IdentityUser> signInManager, ILogger<LogoutModel> logger,
                IEmployeeDataProvider employeeDataProvider, IEditReceptionistCommand editReceptionistCommand)
        {
            _signInManager = signInManager;
            _logger = logger;
            _employeeDataProvider = employeeDataProvider;
            _editReceptionistCommand = editReceptionistCommand;
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            string userName = User.Identity.Name!;
            var user = await _signInManager.UserManager.FindByNameAsync(userName);
            IList<string> roles = await _signInManager.UserManager.GetRolesAsync(user);
            string role = (roles != null && roles.Count > 0) ? roles[0] : "Undefined";
            
            await _signInManager.SignOutAsync();
            _logger.LogWarning($"User {userName} (role: {role}) logged out.");

            if (role == "Receptionist")
            {
                Receptionist receptionist = await _employeeDataProvider.GetReceptionistByIdAsync(Guid.Parse(user.Id));
                if (receptionist != null)
                {
                    receptionist.IsAtWork = false;
                    await _editReceptionistCommand.ExecuteAsync(receptionist);
                }
            }

            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                // This needs to be a redirect so that the browser performs a new
                // request and the identity for the user gets updated.
                return RedirectToPage();
            }
        }
    }
}

using Microsoft.Extensions.Logging;
using System.Text.Encodings.Web;
using System.Text;
using System;
using Microsoft.AspNetCore.Identity;
using GymOffice.Common.DTOs;
using GymOffice.WebAdmin.Data.Contracts;
using GymOffice.WebAdmin.ViewModels;
using GymOffice.Business.Common.Exceptions;
using GymOffice.Common.Utilities.Enums;

namespace GymOffice.WebAdmin.Data
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<IdentityRepository> _logger;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;

        private readonly ICoachDataProvider _coachDataProvider;

        public IdentityRepository(UserManager<IdentityUser> userManager,
                                  SignInManager<IdentityUser> signInManager,
                                  ILogger<IdentityRepository> logger,
                                  IUserStore<IdentityUser> userStore,
                                  //IUserEmailStore<IdentityUser> emailStore,
                                  ICoachDataProvider coachDataProvider)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _userStore = userStore;
            _emailStore = GetEmailStore(); // emailStore;
            _coachDataProvider = coachDataProvider;
        }

        public async Task AddCoachAsync(CoachVM coachVM)
        {
            IdentityUser user = CreateUser();
            user.Id = coachVM.Id.ToString(); // connect the entities
            user.PhoneNumber = coachVM.PhoneNumber;
            // UserName = Email: be careful to change it because the format should correspond to options.User.AllowedUserNameCharacters
            await AddUserWithRoleAsync(user, coachVM.Email, coachVM.Email, coachVM.Password, "Coach");
        }

        public async Task UpdateCoachAsync(Coach coach)
        {
            IdentityUser? user = await GetUserByIdAsync(coach.Id);
            if (user == null)
                throw new NotFoundException(nameof(coach), coach.Id); // this can also be because we did not register all coaches in identity DB
            user.PhoneNumber = coach.PhoneNumber;
            user.Email = coach.Email;
            user.UserName = coach.Email; // be careful to change it because the format should correspond to options.User.AllowedUserNameCharacters
            await _userStore.UpdateAsync(user, CancellationToken.None);
            _logger.LogInformation($"Account information for {user.Email} was changed.");
        }

        public async Task AddReceptionistAsync(ReceptionistVM receptionistVM)
        {
            IdentityUser user = CreateUser();
            user.Id = receptionistVM.Id.ToString(); // connect the entities
            user.PhoneNumber = receptionistVM.PhoneNumber;
            // UserName = Email: be careful to change it because the format should correspond to options.User.AllowedUserNameCharacters
            await AddUserWithRoleAsync(user, receptionistVM.Email, receptionistVM.Email, receptionistVM.Password, "Receptionist");
        }

        public async Task UpdateReceptionistAsync(Receptionist receptionist)
        {
            IdentityUser? user = await GetUserByIdAsync(receptionist.Id);
            if (user == null)
                throw new NotFoundException(nameof(receptionist), receptionist.Id); // this can also be because we did not register all receptionists in identity DB
            user.PhoneNumber = receptionist.PhoneNumber;
            user.Email = receptionist.Email;
            user.UserName = receptionist.Email; // be careful to change it because the format should correspond to options.User.AllowedUserNameCharacters
            await _userStore.UpdateAsync(user, CancellationToken.None);
            _logger.LogInformation($"Account information for {user.Email} was changed.");
        }

        private IdentityUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<IdentityUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(IdentityUser)}'.");
            }
        }

        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The identity UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }

        public async Task<IdentityUser?> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IdentityUser?> GetUserByIdAsync(Guid id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }

        private async Task AddUserWithRoleAsync(IdentityUser user, string userName, string email, string passWord, string role)
        {
            user.PhoneNumberConfirmed = true;
            user.EmailConfirmed = true;
            user.TwoFactorEnabled = false;
            user.LockoutEnabled = false;

            await _userStore.SetUserNameAsync(user, userName, CancellationToken.None);
            await _emailStore.SetEmailAsync(user, email, CancellationToken.None);
            var result = await _userManager.CreateAsync(user, passWord);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
                _logger.LogWarning($"Created a new {role} account for {userName} ({user.Email}) with password.");
            }
        }

    }
}

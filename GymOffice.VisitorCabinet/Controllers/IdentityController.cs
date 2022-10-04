using GymOffice.Business.Commands.EmployeeCommands.Add;
using GymOffice.Common.Contracts.CommandContracts.EmployeeCommands.Add;
using GymOffice.Common.DTOs;
using GymOffice.VisitorCabinet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GymOffice.VisitorCabinet.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly IAddVisitorCommand _addVisitorCommand;
        public IdentityController(
            IConfiguration configuration, 
            UserManager<IdentityUser> userManager, 
            IUserStore<IdentityUser> userStore, IAddVisitorCommand addVisitorCommand)
        {
            _addVisitorCommand = addVisitorCommand;
            _configuration = configuration;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVisitorVM visitor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestErrorMessages();
            }

            var user = await _userManager.FindByEmailAsync(visitor.Email);
            var isAuthorized = user != null && await _userManager.CheckPasswordAsync(user, visitor.Password);

            if (isAuthorized)
            {
                var authResponse = await GetTokens(user);
                //user.RefreshToken = authResponse.RefreshToken;
                //await _userManager.UpdateAsync(user);
                return Ok(authResponse);
            }
            else
            {
                return Unauthorized("Invalid credentials");
            }

        }


        [HttpPost]
        public async Task<IActionResult> Refresh(RefreshRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestErrorMessages();
            }

            //fetch email from expired token string
            var principal = GetPrincipalFromExpiredToken(request.AccessToken);
            var userEmail = principal.FindFirstValue("Email"); //fetch the email claim's value

            //check if any user with email id has matching refresh token
            var user = !string.IsNullOrEmpty(userEmail) ? await _userManager.FindByEmailAsync(userEmail) : null;
            //if (user == null || user.RefreshToken != request.RefreshToken)
            //{
            //    return BadRequest("Invalid refresh token");
            //}

            //provide new access and refresh tokens
            var response = await GetTokens(user);
            //user.RefreshToken = response.RefreshToken;
            //await _userManager.UpdateAsync(user);
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Revoke(RevokeRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestErrorMessages();
            }

            //fetch email from claims of currently logged in user
            var userEmail = HttpContext.User.FindFirstValue("Email");

            //check if any user with email id has matching refresh token
            var user = !string.IsNullOrEmpty(userEmail) ? await _userManager.FindByEmailAsync(userEmail) : null;
            //if (user == null || user.RefreshToken != request.RefreshToken)
            //{
            //    return BadRequest("Invalid refresh token");
            //}

            //remove refresh token 
            //user.RefreshToken = null;
            //await _userManager.UpdateAsync(user);
            return Ok("Refresh token is revoked");
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterVisitorVM visitor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequestErrorMessages();
            }

            var isEmailAlreadyRegistered = await _userManager.FindByEmailAsync(visitor.Email) != null;

            if (isEmailAlreadyRegistered)
            {
                return Conflict($"Email Id {visitor.Email} is already registered.");
            }
            var newUser = new IdentityUser
            {
                Email = visitor.Email,
                PhoneNumber = visitor.PhoneNumber,
                UserName = visitor.FirstName+visitor.LastName
            };
            await _userStore.SetUserNameAsync(newUser, visitor.FirstName + visitor.LastName, CancellationToken.None);
            await _emailStore.SetEmailAsync(newUser, visitor.Email, CancellationToken.None);
            var result = await _userManager.CreateAsync(newUser, visitor.Password);
            //if (result.Succeeded)
            //{
            //    await _addVisitorCommand.ExecuteAsync(new Visitor()
            //    {
            //        Email = visitor.Email,
            //        IsActive = true,
            //        IsInGym = false,
            //        RegistrationDate = DateTime.Now,
            //        FirstName = visitor.FirstName,
            //        LastName = visitor.LastName,
            //        PhoneNumber = visitor.PhoneNumber
            //    });
            //}
            return Ok(result);
        }

        private string GetRefreshToken()
        {
            var token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            //ensure token is unique by checking against db
            //var tokenIsUnique = !_userManager.Users.Any(u => u.RefreshToken == token);

            //if (!tokenIsUnique)
            //    return GetRefreshToken();  //recursive call

            return token;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["token:key"])),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }

        private async Task<AuthResponse> GetTokens(IdentityUser user)
        {
            //create claims details based on the user information
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["token:subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()),
                        new Claim("UserId", user.Id),
                        new Claim("UserName", user.UserName),
                        new Claim("Email", user.Email)
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["token:key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["token:issuer"],
                _configuration["token:audience"],
                claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["token:accessTokenExpiryMinutes"])),
                signingCredentials: signIn);
            var tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

            var refreshTokenStr = GetRefreshToken();
            var authResponse = new AuthResponse { AccessToken = tokenStr, RefreshToken = refreshTokenStr };
            return await Task.FromResult(authResponse);
        }
        private IUserEmailStore<IdentityUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<IdentityUser>)_userStore;
        }
        private IActionResult BadRequestErrorMessages()
        {
            var errMsgs = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
            return BadRequest(errMsgs);
        }
    }
}

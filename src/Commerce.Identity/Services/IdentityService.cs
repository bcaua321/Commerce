using Commerce.Application.Interfaces.Services;
using Commerce.Application.Transfers.Requests;
using Commerce.Application.Transfers.Responses;
using Commerce.Identity.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Commerce.Identity.Services
{
    public class IdentityService : IIdentityService
    {
        private SignInManager<IdentityUser> _signInManager { get; }
        private UserManager<IdentityUser> _userManager { get; }
        private JwtOptions _jwtOptions { get; }

        public IdentityService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IOptions<JwtOptions> jwtOptions)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<UserRegisterResponse> RegisterUser(UserRegisterRequest user)
        {
            var idenityUser = new IdentityUser
            {
                UserName = user.Email,
                Email = user.Email,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(idenityUser, user.Password);
            if (result.Succeeded)
                await _userManager.SetLockoutEnabledAsync(idenityUser, false);

            var userRegisterResponse = new UserRegisterResponse(result.Succeeded);

            if(!result.Succeeded && result.Errors.Count() > 0)
                userRegisterResponse.AddRangeErrors(result.Errors.Select(x => x.Description).ToList());
            
            return userRegisterResponse;
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);

            if (result.Succeeded)
                return await GerarToken(user.Email);

            return new UserLoginResponse(result.Succeeded);
        }


        private async Task<UserLoginResponse> GerarToken(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            var tokenClaims = await ObterClaims(user);

            var dateExpiration = DateTime.Now.AddSeconds(_jwtOptions.Expiration);

            var jwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: tokenClaims,
                notBefore: DateTime.Now,
                expires: dateExpiration,
                signingCredentials: _jwtOptions.SigningCredentials
            );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new UserLoginResponse(true)
            {
                Token= token,
                Expiration = dateExpiration 
            };
        }

        private async Task<IList<Claim>> ObterClaims(IdentityUser user)
        {
            var claims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);


            claims.Add(new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

            foreach (var role in roles)
                claims.Add(new Claim("role", role));

            return claims;
        }
    }
}

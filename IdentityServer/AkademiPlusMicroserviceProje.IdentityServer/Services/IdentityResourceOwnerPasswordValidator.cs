using AkademiPlusMicroserviceProje.IdentityServer.Models;
using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademiPlusMicroserviceProje.IdentityServer.Services
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var existUser=await _userManager.FindByNameAsync(context.UserName);
            if (existUser == null)
            {
                var errors=new Dictionary<string, object>();
                errors.Add("error",new List<string>() { "E-mail veya şifreniz yanlış!"});
                return;
            }
            var passworcheck=await _userManager.CheckPasswordAsync(existUser,context.Password);
            if(passworcheck==false)
            {
                var errors=new Dictionary<string,object>();
                errors.Add("error", new List<string>() { "E-mail veya şifreniz yanlış!" });
                return;
            }
            context.Result = new GrantValidationResult(existUser.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
            
        }
    }
}

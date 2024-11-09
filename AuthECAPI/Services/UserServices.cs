using AuthECAPI.Data;
using AuthECAPI.Interfaces;
using AuthECAPI.Models;
using AuthECAPI.Utilities;
using AuthECAPI.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AuthECAPI.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<AppUser> _userManager;

        public UserServices(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<ReturnResponse<IdentityResult>> UserSignUp(AppUserViewModel appUserViewModel)
        {
            try
            {
                ReturnResponse<IdentityResult> returnResponse = new ReturnResponse<IdentityResult>();
                AppUser user = new AppUser()
                {
                    FullName = appUserViewModel.FullName,
                    Email = appUserViewModel.Email,
                    UserName = appUserViewModel.Email
                };
                var result = await _userManager.CreateAsync(user, appUserViewModel.Password);

                if(result.Succeeded)
                {
                    returnResponse.Success = result.Succeeded;
                    returnResponse.Response = result;
                    return returnResponse;
                }

                returnResponse.Success = result.Succeeded;
                returnResponse.Error = result;
                return returnResponse;
            }
            catch (Exception)
            {
                return new ReturnResponse<IdentityResult>();
            }
        }
    }
}

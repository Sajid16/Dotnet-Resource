using AuthECAPI.Models;
using AuthECAPI.Utilities;
using AuthECAPI.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace AuthECAPI.Interfaces
{
    public interface IUserServices
    {
        Task<ReturnResponse<IdentityResult>> UserSignUp(AppUserViewModel appUserViewModel);
    }
}

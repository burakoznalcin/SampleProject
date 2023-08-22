using SampleProject.Model.Model.Authorize;
using SampleProject.Model.Utilities;
using SampleProject.Model.Utilities.Authentication;

namespace SampleProject.Business.Services.Abstraction
{
    public interface IAuthorizeService
    {
        LoginResponseModel Login(LoginModel loginModel);
        DataResult Register(PersonnelModel personnelModel);
    }
}

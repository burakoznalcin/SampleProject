using SampleProject.Business.Services.Abstraction;
using SampleProject.Business.Utilities.AuthorizeHelpers;
using SampleProject.Model.Authorize;
using SampleProject.Model.Model.Authorize;
using SampleProject.Model.Utilities;
using SampleProject.Model.Utilities.Authentication;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SampleProject.Business.Services.Concretion
{
    public class AuthorizeService : IAuthorizeService
    {
        private readonly IPersonnelService _personnelService;
        private readonly IPersonnelRoleService _personnelRoleService;
        private readonly IRolePrivilegeService _rolePrivilegeService;
        private readonly TokenHelper _tokenHelper;


        public AuthorizeService(IPersonnelService personnelService, IPersonnelRoleService personnelRoleService, IRolePrivilegeService rolePrivilegeService, TokenHelper tokenHelper)
        {
            _personnelService = personnelService;
            _personnelRoleService = personnelRoleService;
            _rolePrivilegeService = rolePrivilegeService;
            _tokenHelper = tokenHelper;
        }

        public LoginResponseModel Login(LoginModel loginModel)
        {
            if (string.IsNullOrEmpty(loginModel.UserName) || string.IsNullOrEmpty(loginModel.Password))
            {
                return new LoginResponseModel
                {
                    Message = "Kullanıcı adı veya şifreniz yanlıştır. Lütfen kontrol ediniz."
                };
            }

            var personnel = _personnelService.GetList(x => x.UserName == loginModel.UserName).FirstOrDefault();

            if (personnel is null)
            {
                return new LoginResponseModel
                {
                    Message = "Kullanıcı adı veya şifreniz yanlıştır. Lütfen kontrol ediniz."
                };
            }

            var hashedPassword = HashingHelper.CreatePasswordHash(loginModel.Password);

            if (!HashingHelper.VerifyPasswordHash(personnel.Password, hashedPassword))
            {
                return new LoginResponseModel
                {
                    Message = "Kullanıcı adı veya şifreniz yanlıştır. Lütfen kontrol ediniz."
                };
            }

            var personnelRoles = _personnelRoleService.GetList(x => x.PersonnelId == personnel.Id && !x.IsDeleted);

            if (personnel is null)
            {
                return new LoginResponseModel
                {
                    Message = "Kullanıcıya ait herhangi bir role bulunamadı."
                };
            }

            var rolePrivileges = _rolePrivilegeService.GetList(x => personnelRoles.Select(x => x.Role.Id).Contains(x.RoleId));

            var roleDtos = new List<Role>();

            foreach (var rolePrivilegeGroup in rolePrivileges.GroupBy(x => x.Role.Id))
            {
                var role = rolePrivilegeGroup.Select(x => x.Role).First();
                var privileges = rolePrivilegeGroup.Select(x => x.Privilege);

                var a = privileges.FirstOrDefault();

                roleDtos.Add(new Role
                {
                    Id = role.Id,
                    Name = role.Name,
                    Privileges = privileges.ToList()
                });
            }

            var tokenModel = new TokenModel
            {
                PersonnelId = personnel.Id,
                Roles = roleDtos.ToList(),
                Username = personnel.UserName
            };

            return new LoginResponseModel
            {
                Token = _tokenHelper.CreateToken(tokenModel),
                IsSuccess = true,
            };
        }

        public DataResult Register(PersonnelModel personnelModel)
        {
            var personnel = _personnelService.GetList(x => x.UserName == personnelModel.UserName || x.Email == personnelModel.Email);

            if (personnel is not null && personnel.Count > 0)
            {
                return new DataResult
                {
                    IsSuccess = false,
                    ErrorMessage = "Kullanıcı adınız veya email adresiniz sistemde mevcuttur lütfen değiştiriniz."
                };
            }

            var hashedPassword = HashingHelper.CreatePasswordHash(personnelModel.Password);

            var dataResult = _personnelService.Add(new PersonnelModel
            {
                Email = personnelModel.Email,
                FirstName = personnelModel.FirstName,
                Password = hashedPassword,
                UserName = personnelModel.UserName,
                Status = personnelModel.Status,
                LastName = personnelModel.LastName,
            });

            if (dataResult.IsSuccess)
            {
                _personnelRoleService.Add(new PersonnelRoleModel
                {
                    Personnel = new PersonnelModel { Id = dataResult.PkId },
                    Role = new RoleModel { Id = 85}
                });

                return new DataResult { IsSuccess = true,PkId = dataResult.PkId };
            }

            return new DataResult { IsSuccess = false };
        }
    }
}

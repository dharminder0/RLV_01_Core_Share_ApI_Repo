using Core.Business.Entites.DataModels;
using Core.Business.Entites.ResponseModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Abstract;
using System.Security.Cryptography;
using System.Text;

namespace Core.Business.Services.Concrete {
    public class UsersService : IUsersService {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository) {
            _usersRepository = usersRepository;
        }


        public object AuthorizeUserDetails(string userName, string password) {
            var userDetails = new UserDetails();
            var userResult = AuthenticateUser(userName, password);
            if (userResult.AuthenticationStatus == "Success") {
                _usersRepository.UpdateUsersAuthentication(userResult.Id);
                userDetails.Id = userResult.Id;
                userDetails.FirstName = userResult.FirstName;
                userDetails.LastName = userResult.LastName;
                userDetails.UserName = userResult.UserName;
                userDetails.Token = userResult.Token;
                userDetails.Phone = userResult.PhoneNumber;
                userDetails.AuthenticationStatus = userResult.AuthenticationStatus;
                userDetails.CountryId = userResult.CountryId;
                userDetails.CityId = userResult.CityId;
                return userDetails;
            }

            userDetails.AuthenticationStatus = "false";
            return userDetails;
        }

        //    public UserInfo GetUserInfoCached(string userToken = "", string clientCode = null, Users userObj = null) {
        //        var key = CachedKeys.GetUserInfoIntegrationKey(userToken, clientCode);
        //        return _cacheApisRepository.GetOrCache<UserInfo>(key, () => {
        //            var result = GetUserInfo(userToken, clientCode, userObj);
        //            return result;
        //        });
        //    }

        //    public UserInfo GetUserInfo(string userToken = "", string clientCode = null, Users userObj = null) {
        //        var user = userObj ??
        //                     _usersRepository.Get(x => x.Token.Equals(userToken, StringComparison.OrdinalIgnoreCase) && x.UserClients.Any(c => c.ClientCode.Equals(clientCode, StringComparison.OrdinalIgnoreCase))).Include("UserClients").SingleOrDefault();
        //        var intercomSettings = _clientIntercomSettingsRepository.Get(ns => ns.ClientCode.Equals(clientCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        //        var officeList = new List<Office>();
        //        var officesParentChild = new List<Office>();
        //        var preferredOffices = new List<Office>();

        //        if (user != null) {
        //            var clientSettings = _clientSettingsRepository.Get(g => g.ClientCode.Equals(clientCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        //            var permissions = _usersRepository.GetUserGrantedPermissions(user.Id).ToList();
        //            var allOffices = _officesRepository.GetAllClientOffices(clientCode);
        //            if (permissions.Contains("Global Office Admin")) {
        //                var branches = allOffices.Where(office => string.IsNullOrWhiteSpace(office.ParentId));
        //                //.Select(o => new Office { Id = o.Id, Name = o.Name }).ToList();
        //                officeList = allOffices.Select(GetOfficeObject).ToList();
        //                officesParentChild = branches.Select(GetOfficeParentChild).ToList();
        //            } else if (!string.IsNullOrWhiteSpace(user.BranchNo)) {
        //                var splittedOffices = user.BranchNo.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        //                var unfilteredOfficeList = allOffices.Where(x => splittedOffices.Contains(x.Id) && x.Clientcode.Equals(clientCode, StringComparison.OrdinalIgnoreCase));
        //                officeList = unfilteredOfficeList.Select(x => new Office {
        //                    Id = x.Id,
        //                    Name = x.Name
        //                }).ToList();
        //                var parentOfficeid = unfilteredOfficeList.Where(v => !string.IsNullOrWhiteSpace(v.ParentId)).Select(v => v.ParentId);
        //                if (parentOfficeid != null && parentOfficeid.Any()) {
        //                    splittedOffices.AddRange(parentOfficeid.ToList());
        //                }
        //                var branches = allOffices.Where(office => string.IsNullOrWhiteSpace(office.ParentId)).ToList();
        //                officesParentChild = branches.Where(A => splittedOffices.Contains(A.Id)).Select(x => GetOfficeParentChild(x, splittedOffices)).ToList();
        //            }
        //            //else {
        //            //    var offic = _officesRepository.Get(o => o.Id == "01230-10026").ToList();
        //            //    if (offic.Any()) {
        //            //        officeList = offic
        //            //      .Select(x => new Office {
        //            //          Id = x.Id,
        //            //          Name = x.Name
        //            //      }).ToList();
        //            //    }
        //            //}
        //            if (!string.IsNullOrWhiteSpace(user.PreferredBranches)) {
        //                var splittedOffices = user.PreferredBranches.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        //                preferredOffices = allOffices.Where(x => splittedOffices.Contains(x.Id)).Select(x => new Office {
        //                    Id = x.Id,
        //                    Name = x.Name
        //                }).ToList();
        //            }

        //            //var permissions = userPermissions
        //            //    .Select(p => p.Id).Distinct().ToList();

        //            var headers = new List<HeaderMenus>();

        //            List<UserMenuDto> userMenus = new List<UserMenuDto>();
        //            if (string.IsNullOrWhiteSpace(clientCode)) {
        //                clientCode = user.ClientCode;
        //            }

        //            if (!string.IsNullOrWhiteSpace(clientCode)) {
        //                var clientMenus = _clientSettingsService.GetClientMenusWithCulture(clientCode).ToList();
        //                clientMenus?.ForEach(cm => {
        //                    cm.Menus = cm.Menus.Where(item => (permissions.Exists(p => p == item.Permission || string.IsNullOrWhiteSpace(item.Permission))
        //                                                       && !item.SubMenus.Any())
        //                                                      ||
        //                                                      item.SubMenus.Any(sitem => permissions.Exists(p => p == sitem.Permission || string.IsNullOrWhiteSpace(sitem.Permission)))
        //                        ).Select(m => m).ToList();
        //                    cm.Menus.ToList().ForEach(sm => {
        //                        sm.SubMenus = sm.SubMenus.Where(sitem => permissions.Exists(p => p == sitem.Permission || string.IsNullOrWhiteSpace(sitem.Permission))).ToList();
        //                    });
        //                });
        //                clientMenus?.ForEach(cm => {
        //                    userMenus.Add(new UserMenuDto {
        //                        Culture = cm.Culture,
        //                        Menus = cm.Menus.Select(m => new UserMenuItemDto {
        //                            Name = m.Name,
        //                            StandardName = m.StandardName,
        //                            Description = m.Description,
        //                            Url = m.Url + (m.Url.IndexOf("?") > -1 ? "&companycode=" : "?companycode=") + clientCode.ToLower(),
        //                            Placement = m.Placement,
        //                            SortOrder = m.SortOrder,
        //                            OpenNewTab = m.OpenNewTab,
        //                            SubMenus = m.SubMenus.Select(sm => new UserMenuItemDto { Name = sm.Name, StandardName = sm.StandardName, Description = sm.Description, Url = sm.Url + (sm.Url.IndexOf("?") > -1 ? "&companycode=" : "?companycode=") + clientCode.ToLower(), Placement = sm.Placement, SortOrder = sm.SortOrder, OpenNewTab = sm.OpenNewTab }).OrderBy(x => x.SortOrder).ToList()
        //                        }).OrderBy(x => x.SortOrder).ToList()
        //                    });
        //                });
        //            }

        //            // Technical Recruiter Skill Courses
        //            List<TechnicalRecruiterSkillCourse> recruiterSkillCourses = new List<TechnicalRecruiterSkillCourse>();
        //            var userRecruiterSkillCourses = _recruiterSkillsCourseRepository.Get(x => permissions.Contains(x.Permission)).ToList();

        //            string userHash = null;
        //            if (intercomSettings != null) {
        //                byte[] bytes = Encoding.UTF8.GetBytes(user.UserName);
        //                HMACSHA256 hmac = new HMACSHA256(Encoding.UTF8.GetBytes(intercomSettings.IdentityVerificationSecret.ToString()));
        //                byte[] hash = hmac.ComputeHash(bytes);
        //                string hashString = hash.Aggregate(string.Empty, (current, x) => current + $"{x:x2}");
        //                userHash = hashString;
        //            }
        //            string shortBranchNo = null;
        //            if (!string.IsNullOrWhiteSpace(user.BranchNo)) {
        //                shortBranchNo = string.Join(",", Regex.Matches(user.BranchNo, @"(\d+)").Cast<Match>().Select(x => x.Value).Take(50).ToList());
        //                if (shortBranchNo.EndsWith(",")) {
        //                    shortBranchNo = shortBranchNo.Substring(shortBranchNo.Length - 1, 1);
        //                }
        //            }
        //            var workRoles = _userWorkRoleRepository.Get(x => x.UserId == user.Id).Select(u => new WorkRoleDto { Id = u.WorkRoleId, Name = u.WorkRole.DisplayName })
        //                .Distinct()
        //                .ToList();

        //            var resultUser = new UserInfo {
        //                UserId = user.Id,
        //                FirstName = user.FirstName,
        //                LastName = user.LastName,
        //                NickName = user.NickName,
        //                Initials = user.Initials,
        //                UserName = user.UserName,
        //                Mail = clientSettings?.ParentClientCode == null ? user.Mail : user.UserClients.First(uc => uc.ClientCode.Equals(clientCode, StringComparison.InvariantCultureIgnoreCase))?.Email,
        //                Avatar = user.Avatar,
        //                AvatarPublicId = user.AvatarPublicId,
        //                Thumbnail = user.Thumbnail,
        //                DisplayName = user.DisplayName,
        //                Offices = officeList,
        //                OfficesParentChild = officesParentChild,
        //                PreferredOffices = preferredOffices,
        //                BranchNo = user.BranchNo,
        //                DateStart = user.DateStart,
        //                Gender = user.Gender,
        //                PhoneNumber = clientSettings?.ParentClientCode == null ? user.PhoneNumber : user.UserClients.First(uc => uc.ClientCode.Equals(clientCode, StringComparison.InvariantCultureIgnoreCase))?.PhoneNo,
        //                BirthDate =
        //                    user.BirthDate != null && user.BirthDate.Value != null
        //                        ? user.BirthDate.Value.ToString("dd-MM-yyyy", CultureInfo.InvariantCulture)
        //                        : string.Empty,
        //                Token = user.Token,
        //                AccessToken = user.AccessToken,
        //                TimeZone = user.TimeZone,
        //                Offset = GetTZOffset(user.TimeZone),
        //                ActiveLanguage = user.ActiveLanguage,
        //                HeaderMenus = headers,
        //                HeaderMenusNew = userMenus,
        //                IsAppointmentAdmin = permissions.IndexOf("Afspraken Beheerder") > -1,
        //                Permissions = permissions,
        //                IntercomUserHash = userHash,
        //                TechnicalRecruiterSkillsCourses = userRecruiterSkillCourses,
        //                GtmContainerId = clientSettings?.GTMCode,
        //                WorkRoles = workRoles
        //            };
        //            // update user data with new claims data
        //            return resultUser;
        //        }
        //        return null;
        //    }
        //}


        public UserDto AuthenticateUser(string userName, string password) {
            var user = new UserDto();
            var dbUser = _usersRepository.GetUsersAuthentication(userName).FirstOrDefault();
            if (dbUser != null && Convert.ToBoolean(dbUser.IsVerified) && dbUser.PasswordSalt != null) {
                var saltBytes = dbUser.PasswordSalt;
                var hashedPassword = HashPassword(password, ref saltBytes);
                if (hashedPassword == dbUser.Password) {
                    user = MapUserToUserDto(dbUser);
                    user.AuthenticationStatus = "Success";
                    return user;
                }
            } else {
                //var user = new UserDto();
                if (dbUser == null)
                    user.AuthenticationStatus = "Failed";
                else if (!Convert.ToBoolean(dbUser.IsVerified))
                    user.AuthenticationStatus = "NotVerified";
                return user;
            }
            return user;
        }

        private string HashPassword(string password, ref byte[] saltBytes) {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            saltBytes = saltBytes ?? GetSalt();
            var saltedPasswordBytes = GenerateSaltedHash(passwordBytes, saltBytes);
            byte[] hashBytes;
            using (var algorithm = new System.Security.Cryptography.SHA512Managed()) {
                hashBytes = algorithm.ComputeHash(saltedPasswordBytes);
            }
            return Convert.ToBase64String(hashBytes);
        }

        private byte[] GenerateSaltedHash(byte[] plainText, byte[] salt) {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++) {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++) {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        private static byte[] GetSalt() {
            var salt = new byte[32];
            using (var random = new RNGCryptoServiceProvider()) {
                random.GetNonZeroBytes(salt);
            }
            return salt;
        }

        private UserDto MapUserToUserDto(Users dbUser) {
            UserDto user = new UserDto();
            user.Id = dbUser.Id;
            user.FirstName = dbUser.FirstName;
            user.LastName = dbUser.LastName;
            user.UserName = dbUser.UserName;
            user.PhoneNumber = dbUser.Phone;
            user.Token   = dbUser.Token;
            user.CountryId   = dbUser.CountryId ?? 0;
            user.CityId   = dbUser.CityId ?? 0;
            return user;
        }

    }
}
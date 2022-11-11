using Core.Business.Entites;
using Core.Business.Entites.DataModels;
using Core.Business.Entites.Dto;
using Core.Business.Entites.ResponseModels;
using Core.Business.Services.Abstract;
using Core.Data.Repositories.Abstract;
using System.Security.Cryptography;
using System.Text;

namespace Core.Business.Services.Concrete {
    public class UsersService : IUsersService {
        private readonly IUsersRepository _usersRepository;
        private readonly IMediaFileRepository _mediaFileRepository;

        public UsersService(IUsersRepository usersRepository, IMediaFileRepository mediaFileRepository) {
            _usersRepository = usersRepository;
            _mediaFileRepository = mediaFileRepository;
        }


        public object Userlogin(string userName, string password) {
            var userDetails = new UserDetails();
            var userResult = AuthenticateUser(userName, password);
            if (userResult.AuthenticationStatus == "Success") {
                _usersRepository.UpdateLastlogin(userResult.Id);
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

        public object GetUserInfoByToken(string accessToken) {
            var usersDetails = new UsersDetails();
            try {
                var dbUser = _usersRepository.GateUsersDetailsByToken(accessToken).FirstOrDefault();
                if (dbUser != null) {
                    usersDetails.Users = MapUserToUserBasicDto(dbUser);
                    var files = _mediaFileRepository.GetEntityMediaFile(dbUser.Id, Entites.EntityType.User);
                    if (files != null && files.Any()) {
                        usersDetails.Images = new List<MediaFileDto>();
                        foreach (var item in files) {
                            usersDetails.Images = new List<MediaFileDto>
                            {
                                new MediaFileDto
                                {
                                    FileName  = item.FileName,
                                    FileUrl= item.BlobLink ,
                                    FileType = Enum.GetName(typeof(MediaType),item.MediaTypeId)
                                }
                            };
                        }
                    }
                    return usersDetails;
                }
                return null;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public object UsersInfoById(int id) {
            var usersDetails = new UsersDetails();
            try {
                if (id > 0) {
                    var dbUser = _usersRepository.GateUsersInfoById(id).SingleOrDefault();
                    if (dbUser != null) {
                        usersDetails.Users = MapUserToUserBasicDto(dbUser);
                        var files = _mediaFileRepository.GetEntityMediaFile(dbUser.Id, Entites.EntityType.User);
                        if (files != null && files.Any()) {
                            usersDetails.Images = new List<MediaFileDto>();
                            foreach (var item in files) {
                                usersDetails.Images = new List<MediaFileDto>
                                {
                                    new MediaFileDto
                                    {
                                     FileName  = item.FileName,
                                     FileUrl= item.BlobLink ,
                                     FileType = Enum.GetName(typeof(MediaType),item.MediaTypeId)
                                    }
                                };
                            }
                        }
                        return usersDetails;
                    }
                }
                return null;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public bool AddUpdateUser(RequestUser obj) {
            try {
                var response = _usersRepository.InsertUser(obj);
                if (response == true) {
                    return true;
                }
                return false;
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public UserDto AuthenticateUser(string userName, string password) {
            var user = new UserDto();
            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrEmpty(password)) {
                var dbUser = _usersRepository.GetUsersAuthenticatioByUserName(userName).FirstOrDefault();
                if (dbUser != null && Convert.ToBoolean(dbUser.IsVerified) && dbUser.PasswordSalt != null) {
                    var saltBytes = dbUser.PasswordSalt;
                    var hashedPassword = HashPassword(password, ref saltBytes);
                    if (hashedPassword == dbUser.Password) {
                        user = MapUserToUserDto(dbUser);
                        user.AuthenticationStatus = "Success";
                        return user;
                    }
                } else {
                    if (dbUser == null)
                        user.AuthenticationStatus = "Failed";
                    else if (!Convert.ToBoolean(dbUser.IsVerified))
                        user.AuthenticationStatus = "NotVerified";
                    return user;
                }
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
            user.Token = dbUser.Token;
            user.CountryId = dbUser.CountryId ?? 0;
            user.CityId = dbUser.CityId ?? 0;
            return user;
        }
        private UserBasicDto MapUserToUserBasicDto(Users dbUser) {
            UserBasicDto user = new UserBasicDto();
            user.Id = dbUser.Id;
            user.FirstName = dbUser.FirstName;
            user.LastName = dbUser.LastName;
            user.UserName = dbUser.UserName;
            user.PhoneNumber = dbUser.Phone;
            user.Token = dbUser.Token;
            user.CountryId = dbUser.CountryId ?? 0;
            user.CityId = dbUser.CityId ?? 0;
            return user;
        }


    }
}
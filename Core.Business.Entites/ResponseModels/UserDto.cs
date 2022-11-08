using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entites.ResponseModels {
        public class UserDto {
            public long Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string NickName { get; set; }
            public string Gender { get; set; }
            public string PhoneNumber { get; set; }
            public string BirthDate { get; set; }
            public string OfficeId { get; set; }
            public string OfficeName { get; set; }
            public string Avatar { get; set; }
            public string AvatarPublicId { get; set; }
            public string ProfileSelectedArea { get; set; }
            public string OriginalAvatarUrl { get; set; }
            public string UserName { get; set; }
            public string Department { get; set; }
            public string DisplayName { get; set; }
            public string FunctionNo { get; set; }
            public string BranchNo { get; set; }
            public string DateStart { get; set; }
            public string Initials { get; set; }
            public string Token { get; set; }
            public string[] LastBranchSelection { get; set; }
            public string[] LastUsersSelection { get; set; }
            public string[] LastClientsSelection { get; set; }
            public List<string> LastSelectedFunctionsKeys { get; set; }
            public double LastMaxMarginSelection { get; set; }
            public double LastMinMarginSelection { get; set; }
            public string LastSearchTypeSelected { get; set; }
            public bool? IsPilot { get; set; }
            public string[] Permissions { get; set; }
            public string Password { get; set; }
            public bool VerificationEmailSent { get; set; }
            public string AuthenticationStatus { get; set; }
            public string AccessToken { get; set; }
            public bool? IsLocked { get; set; }
            public int? PasswordTraials { get; set; }
            public string Thumbnail { get; set; }
            public string CompanyName { get; set; }
            public string Mail { get; set; }
            public string MailNickname { get; set; }
            public string PostalCode { get; set; }
            public string SamAccountName { get; set; }
            public string Title { get; set; }
            public string ClientCode { get; set; }
            public string PreferredBranches { get; set; }
            public string DefaultReturnUrl { get; set; }
            public string ExternalAccessToken { get; set; }
            public string ExternalRefreshToken { get; set; }
            public string ExternalUserId { get; set; }
            public string ActiveLanguage { get; set; }
            public string TimeZone { get; set; }
            public string Brands { get; set; }
            public List<UserCompanyDto> CompanyList { get; set; }
        }

        public class UserCompanyDto {
            public string ClientCode { get; set; }
            public string LogoUrl { get; set; }
            public string CompanyName { get; set; }
            public string Email { get; set; }
            public string PhoneNo { get; set; }
        }

        public class UserDetails {
            public long Id { get; set; }
            public string AccessToken { get; set; }
            public string DefaultReturnUrl { get; set; }
            public string AuthenticationStatus { get; set; }
            public int? PasswordTraials { get; set; }
            public string Token { get; set; }
            public string ClientCode { get; set; }
        }

        public class UserGraphObject {
            public string Id { get; set; }
            public List<string> BusinessPhones { get; set; }
            public string DisplayName { get; set; }
            public string GivenName { get; set; }
            public string Surname { get; set; }
            public string Department { get; set; }
            public string JobTitle { get; set; }
            public string Mail { get; set; }
            public string MailNickname { get; set; }
            public string MobilePhone { get; set; }
            public string PostalCode { get; set; }
            public object OfficeLocation { get; set; }
            public object PreferredLanguage { get; set; }
            public string SamAccountName { get; set; }
            public string UserPrincipalName { get; set; }
        }

        public class UserGraphObjectList {
            public List<UserGraphObject> Value { get; set; }
        }

        public class UserSearchResult {
            public long Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Mail { get; set; }
            public string Branchs { get; set; }
            public string PreferredBranches { get; set; }
            public int[] Roles { get; set; }
        }



        public class UserBasicDto {
            public long Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Phone { get; set; }
            public string Mail { get; set; }
            public string ClientCode { get; set; }
            public DateTime? CreatedOn { get; set; }
        }

        public class UserBasicData {
            public long Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Phone { get; set; }
            public string BirthDate { get; set; }
            public string Address { get; set; }
            public string Gender { get; set; }
            public string[] Offices { get; set; }
            public int[] Roles { get; set; }
            public int[] WorkRoles { get; set; }
            public string ClientCode { get; set; }
            public string VerificationToken { get; set; }
            public string Avatar { get; set; }
            public string CoverImage { get; set; }
            public bool IsModified { get; set; } = false;
            public string ActiveLanguage { get; set; }
            public string TimeZone { get; set; }
            public string PreferredBranches { get; set; }
            public string BranchNo { get; set; }
            public string AvatarPublicId { get; set; }
            public string Mail { get; set; }
            public string Brands { get; set; }
        }

        public class RecruiterDefaultModel {
            public int UserId { get; set; }
            public string ClientCode { get; set; }
            public string TeaserText { get; set; }
            public string WelcomeText { get; set; }
            public string TeaserVideoId { get; set; }
            public string AppointmentId { get; set; }
            public List<string> CalendarId { get; set; }
            public string TeaserVideoUrl { get; set; }
            public bool ShowEmailField { get; set; }
            public bool IsWorkflowConfigured { get; set; }
            public string WorkflowName { get; set; }
        }

        public class RecruiterChatbotResponse : RecruiterDefaultModel {
            public string Calendar { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string PhoneNumber { get; set; }
            public string Mail { get; set; }
            public string Avatar { get; set; }
            public string AvatarPublicId { get; set; }
        }
    
}

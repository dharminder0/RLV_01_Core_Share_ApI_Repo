using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entites.ResponseModels {
    public class UserInfo {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string BirthDate { get; set; }
        public List<Office> Offices { get; set; }
        public List<Office> OfficesParentChild { get; set; }
        public string Avatar { get; set; }
        public string AvatarPublicId { get; set; }
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public string BranchNo { get; set; }
        public string DateStart { get; set; }
        public string Initials { get; set; }
        public string Token { get; set; }
        public string TimeZone { get; set; }
        public string ActiveLanguage { get; set; }
        public List<HeaderMenus> HeaderMenus { get; set; }
        public List<UserMenuDto> HeaderMenusNew { get; set; }
        public double Offset { get; set; }
        public string Thumbnail { get; set; }
        public string AccessToken { get; set; }
        public bool IsAppointmentAdmin { get; set; }
        public List<Office> PreferredOffices { get; set; }
        public IEnumerable<string> Permissions { get; set; }
        public string IntercomUserHash { get; set; }
        public string IntercomBranchNo { get; set; }
        public string PreferredLanguage { get; set; }
       // public List<TechnicalRecruiterSkillCourse> TechnicalRecruiterSkillsCourses { get; set; }
        public string GtmContainerId { get; set; }
      //  public List<WorkRoleDto> WorkRoles { get; set; }
    }

    public class Office {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Office> Children { get; set; }
    }

    public class HeaderMenu {
        public byte Level { get; set; }
        public string MenuText { get; set; }
        public string MenueUrl { get; set; }
    }

    public class UserMenuDto {
        public string Culture { get; set; }
        public List<UserMenuItemDto> Menus { get; set; }
    }

    public class UserMenuItemDto {
        public string Name { get; set; }
        public string StandardName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Placement { get; set; }
        public int? SortOrder { get; set; }
        public bool? OpenNewTab { get; set; }
        public virtual List<UserMenuItemDto> SubMenus { get; set; }
    }

    public class HeaderMenus {
        public string Culture { get; set; }
        public List<HeaderMenu> Menus { get; set; }
    }

    public class TimeZoneUpdateRequest {
        public string UserToken { get; set; }
        public string TimeZone { get; set; }
    }

    public class BusinessUserInfo {
        public long UserId { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string AccessToken { get; set; }
        public string DisplayName { get; set; }
        public string NickName { get; set; }
        public string Gender { get; set; }
        public string BirthDate { get; set; }
        public string Avatar { get; set; }
        public string AvatarPublicId { get; set; }
        public string Thumbnail { get; set; }
        public string BranchNo { get; set; }
        public string PreferredBranches { get; set; }
        public string ActiveLanguage { get; set; }
        public string TimeZone { get; set; }
        public List<string> Permissions { get; set; }
        public List<Office> Offices { get; set; }
        public List<Office> OfficesParentChild { get; set; }

        public string ExternalAccessToken { get; set; }
        public string ExternalRefreshToken { get; set; }
        public string ExternalUserId { get; set; }
    }


    public class UserGeneralInfo {
        public long UserId { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Avatar { get; set; }
        public string AvatarPublicId { get; set; }
        public string ExternalUserId { get; set; }
    }

    public class OfficeUser {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Avatar { get; set; }
        public string AvatarPublicId { get; set; }
        public string Token { get; set; }
    }
}

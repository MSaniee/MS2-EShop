using System;

namespace MS2EShop.Application.Dtos.Users
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool IsActive { get; set; }
    }
}

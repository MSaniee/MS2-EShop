using Mapster;
using MS2EShop.Application.Mapping.Mapster;
using MS2EShop.Domain.Core.Utilities.PagesSettings;
using MS2EShop.Domain.Entities.UserAggregate;
using System;
using System.Collections.Generic;

namespace MS2EShop.Application.Dtos.Users
{
    public class UserDto : IBaseMapster
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string ProfilePicture { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool IsActive { get; set; }

        public void Register(TypeAdapterConfig config)
        {
            config.ForType<User, UserDto>()
                  .Map(dest => dest.FullName, src => src.FirstName + " " + src.LastName);
        }
    }

    public class UsersDto
    {
        public List<UserDto> Users { get; set; }
        public Pagination Pagination { get; set; }
    }
}

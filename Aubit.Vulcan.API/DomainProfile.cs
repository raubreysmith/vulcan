using AutoMapper;
using Aubit.Vulcan.API.Entities;
using Aubit.Vulcan.API.Models;

namespace Aubit.Vulcan.API
{
    public class DomainProfile: Profile
    {
        public DomainProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
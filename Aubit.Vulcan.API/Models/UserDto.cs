using System.Runtime.Serialization;

namespace Aubit.Vulcan.API.Models
{
    [DataContract(Name="User")]
    public class UserDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }  
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    [DataContract(Name="User")]
    public class CreateUserDto
    {
        public string FirstName { get; set; }  
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
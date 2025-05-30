using System.ComponentModel.DataAnnotations;
using Jcf.WhereToPark.Api.Core.Constants;
using Jcf.WhereToPark.Api.Core.Entities;

namespace Jcf.WhereToPark.Api.Application.User.Entities
{
    public class User : EntityBase
    {
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Name { get; private set; }

        [Required]
        [StringLength(256, MinimumLength = 3)]
        public string Email { get; private set; }

        [Required]
        [StringLength(256, MinimumLength = 6)]
        public string Password { get; private set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Login { get; private set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Role { get; set; } = RolesConstants.BASIC;

        public User(string name, string email, string password, string login, string role) : base()
        {
            Name = name;
            Email = email;
            Password = password;
            Login = login;
            Role = role;
        }

        public User(string name, string email, string password, string login, string role, Guid? userCreateId) : base(userCreateId)
        {
            Name = name;
            Email = email;
            Password = password;
            Login = login;
            Role = role;
        }

        public User(Guid id, string name, string email, string password, string login, string role, Guid? userCreateId) : base(id, userCreateId)
        {
            Name = name;
            Email = email;
            Password = password;
            Login = login;
            Role = role;
        }

        private User() : base()
        {
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            Login = string.Empty;
        }
    }
}

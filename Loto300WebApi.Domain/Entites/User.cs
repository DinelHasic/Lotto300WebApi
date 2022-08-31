using Loto300WebApi.Domain.Entites;
using Loto300WebApi.Domain.Enum;

namespace Loto3000App.Models
{
    public class User : BaseEntity
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }

        public User()
        {

        }

        public User(int id, string firstName, string lastName, string userName, string password,UserType userType)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Password = password;
            UserType = userType;
        }
    }
}

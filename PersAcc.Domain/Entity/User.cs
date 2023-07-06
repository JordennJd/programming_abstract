using PersAcc.Domain.Interfaces;

namespace PersAcc.Domain.Entity
{
    public class User : IUser
    {

        public string FirstName { get; set; }
        public string LastName { get;  set; }
        public string Password { get; }
        public string Email { get; }
        public User(string FN,string LN, string password, string email)
        {
            FirstName = FN;
            LastName = LN;
            Password = password;
            Email = email;
        }

    }
}

namespace PersAcc.Domain.Interfaces
{

    public interface IUser
    {
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Password { get; }
        public string Email { get; }

    }
}

using Telegram.Bot.Types;

namespace TelegramBot
{
    class User
    {
        public string role;
        public string modification;
        public string id;
        public string name;
        public User(string UserId,string UserName,string Role = "member", string Modification = null)
        {
            this.name = UserName;
            this.id = UserId;
            this.role = Role;
            this.modification = Modification;
        }

    }
}
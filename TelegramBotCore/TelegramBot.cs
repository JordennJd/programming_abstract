using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramAndSQL.TimeTableCore;

namespace TelegramBot
{
    sealed class TelegramBot
    {
        async internal static Task Update(ITelegramBotClient BotClient, Update update, CancellationToken arg3)
        {

            Message Message = update.Message;
            switch (Message.Text) // Переделать все через кнопки
            {
                case ("/start"):
                    MainNode.Programm.userUpdater(new User(Message.From.Id.ToString(), Message.From.Username.ToString()));
                    break;
                case ("/newpair"):
                    await BotClient.SendTextMessageAsync(Message.Chat.Id,
                        "Введите информацию о паре в виде \nИнфо\\НомерПары(число)\\ДеньНедели(число)\\Модификатор");
                    break;
            }
            if (Message.Text.Contains("\\"))
            {
                string[] information = Message.Text.Split("\\");
                Console.WriteLine(information[0]);
                if (information.Length == 4) //добавить защиту от неправлильного ввода данных
                    MainNode.Programm.TbUpdater(new Lesson(information[0], information[1], information[2], information[3]));
            }
        }

        internal static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3) //Обработка каких то ошибок
        {

            throw new NotImplementedException();
        }
    }

} 


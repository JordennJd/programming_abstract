using System;
using Telegram.Bot;
using Telegram.Bot.Types;

using TelegramBot;
using DataBaseCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MainNode{
    class Programm 
    {
        public delegate void UserUpdater(TelegramBot.User user);//Делегаты для сообщения бота с базой данных
        public static UserUpdater userUpdater = DataBaseCore.DataHandler.AddUserInDB;
        public delegate void TBUpdater(List<TelegramAndSQL.TimeTableCore.Lesson> lessons);
        public static TBUpdater TbUpdater = DataBaseCore.DataHandler.AddULessonInDB;

        private static string token = "6023689671:AAFTPEPJpWXSmJDXZF4lQZlvYvIciDAS1HI";
        static void Main()
        {
            TelegramBotClient BotClient = new TelegramBotClient(token);
            BotClient.StartReceiving(TelegramBot.TelegramBot.Update, TelegramBot.TelegramBot.Error);
            Console.ReadLine();
        }

    }
}
using System;
using System.Configuration;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace CalendarBot.ConsoleApp
{
    internal class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient(ConfigurationManager.AppSettings["BotToken"]);

        public static async Task Main()
        {
            var calendarBot = await Bot.GetMeAsync();
            Console.Title = calendarBot.Username;

            Bot.OnMessage += BotOnOnMessage;

            return;
        }

        private static void BotOnOnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            throw new NotImplementedException();
        }
    }
}

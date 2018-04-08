using CalendarBot.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace CalendarBot.ConsoleApp
{
    internal class BotRunner
    {
        public static readonly TelegramBotClient Bot = new TelegramBotClient(AppBotConfiguration.TelegramBotToken);

        private static async Task Main()
        {
            var me = await Bot.GetMeAsync();
            Console.Title = me.Username;

            Bot.OnMessage += BotOnMessage;

            Bot.StartReceiving(Array.Empty<UpdateType>());
            Console.WriteLine($@"Start listening for {me.Username}");
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static void BotOnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            //Usuario ta no messageEventArgs.Message.chat.username
            var message = messageEventArgs.Message;

            if (message == null || message.Type != MessageType.TextMessage)
            {
                return;
            }

            Console.WriteLine(message.Text);

            switch (message.Text.Split(' ').FirstOrDefault())
            {
                case "/start":
                    {
                        //Criar rota para fazer o login
                        break;
                    }
                default:
                    {
                        Console.WriteLine(@"Erro");
                        break;
                    }

            }
        }
    }
}
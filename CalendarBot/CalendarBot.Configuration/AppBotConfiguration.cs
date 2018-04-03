using Newtonsoft.Json;
using System.IO;

namespace CalendarBot.Configuration
{
    public class AppBotConfiguration
    {
        public static string TelegramBotToken;
        static AppBotConfiguration()
        {
            using (var reader = new StreamReader("BotToken.json"))
            {
                var json = reader.ReadToEnd();
                var config = JsonConvert.DeserializeObject<TelegramConfigToken>(json);
                TelegramBotToken = config.BotToken;
            }
        }
    }

    public class TelegramConfigToken
    {
        public string BotToken { get; set; }
    }

}

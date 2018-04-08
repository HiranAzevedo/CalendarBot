using System.Threading.Tasks;
using System.Web.Http;

namespace CalendarBot.WebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public async Task<string> Get()
        {
            var botClient = new Telegram.Bot.TelegramBotClient("your API access Token");
            var me = await botClient.GetMeAsync();
            System.Console.WriteLine($@"Hello! My name is {me.FirstName}");
            return $"Hello! My name is {me.FirstName}";
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

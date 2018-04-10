using CalendarBot.Configuration;
using CalendarBot.Repository.Context;
using CalendarBot.Repository.Repositories;
using CalendarBot.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalendarBot.Domain.Entities;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineKeyboardButtons;
using Telegram.Bot.Types.ReplyMarkups;

namespace CalendarBot.ConsoleApp
{
    internal class BotRunner
    {
        public static readonly TelegramBotClient Bot = new TelegramBotClient(AppBotConfiguration.TelegramBotToken);
        public static readonly DataBase Db = new DataBase();
        public static CalendarRepository Repository = new CalendarRepository(Db);
        public static CalendarService Service = new CalendarService(Repository);
        public static List<OncePerDayTimer> Alerts = new List<OncePerDayTimer>();

        private static async Task Main()
        {
            var me = await Bot.GetMeAsync();
            Console.Title = me.Username;

            Bot.OnMessage += BotOnMessage;
            Bot.OnInlineResultChosen += BotOnInlineResultChosen;
            Bot.OnCallbackQuery += BotOnCallbackQuery;
            Bot.OnInlineQuery += BotOnInlineQuery;
            Bot.OnReceiveError += BotOnReceiveError;

            Bot.StartReceiving(Array.Empty<UpdateType>());
            Console.WriteLine($@"Start listening for {me.Username}");
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            Console.WriteLine(@"Received error: {0} — {1}",
                receiveErrorEventArgs.ApiRequestException.ErrorCode,
                receiveErrorEventArgs.ApiRequestException.Message);
        }

        private static void BotOnInlineQuery(object sender, InlineQueryEventArgs inlineQueryEventArgs)
        {
            Console.WriteLine($@"Received inline query from: {inlineQueryEventArgs.InlineQuery.From.Id}");
        }

        private static async void BotOnCallbackQuery(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            var callbackQuery = callbackQueryEventArgs.CallbackQuery;

            if (callbackQuery.Data.Contains("/FeriadosMes"))
            {
                var month = Convert.ToInt32(callbackQuery.Data.Split(' ')[1]);
                var calendar = Service.GetById("System-Holiday");

                var events = calendar.Events.Where(x => x.StartDate.Month == month);
                var builder = new StringBuilder();

                foreach (var @event in events)
                {
                    builder.AppendLine($@"{@event.Title} - {@event.StartDate:d}");
                }

                builder.AppendLine("that's all");

                await Bot.SendTextMessageAsync(
                    callbackQuery.Message.Chat.Id,
                    builder.ToString());
            }

            if (callbackQuery.Data.Contains("/ListarEventosAgendaMensal"))
            {
                var month = Convert.ToInt32(callbackQuery.Data.Split(' ')[1]);
                var calendar = Service.GetById(callbackQuery.Message.Chat.Username);

                var events = calendar.Events.Where(x => x.StartDate.Month == month).ToList();

                var builder = new StringBuilder();
                builder.AppendLine($"Month {month} events :");

                if (events.Count() > default(int))
                {
                    foreach (var @event in events)
                    {
                        builder.AppendLine($"{@event.Title} -> {@event.StartDate:g} - {@event.EndDate:g}");
                    }
                }

                await Bot.SendTextMessageAsync(
                    callbackQuery.Message.Chat.Id,
                    builder.ToString());
            }

            //await Bot.AnswerCallbackQueryAsync(
            //    callbackQuery.Id,
            //    $"Received {callbackQuery.Data}");

            //await Bot.SendTextMessageAsync(
            //    callbackQuery.Message.Chat.Id,
            //    $"Received {callbackQuery.Data}");
        }

        private static void BotOnInlineResultChosen(object sender, ChosenInlineResultEventArgs chosenInlineResultEventArgs)
        {
            Console.WriteLine($@"Received inline result: {chosenInlineResultEventArgs.ChosenInlineResult.ResultId}");
        }

        private static async void BotOnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;

            if (message == null || message.Type != MessageType.TextMessage)
            {
                return;
            }

            Console.WriteLine(message.Text);

            switch (message.Text.Split(' ').FirstOrDefault())
            {
                case "/Start":
                case "/start":
                    {
                        var builder = new StringBuilder();
                        builder.AppendLine("/AgendaInfDia hour:min -> comand to set an alert at this time");
                        builder.AppendLine("/FeriadosMes -> command to list holidays of one mouth");
                        builder.AppendLine("/ListarEventosAgendaMensal -> list of the selected month events");
                        builder.AppendLine("/CriarEvento dd/mm/yy hh:mm - dd/mm/yy hh:mm - title -> create a new event in calendar");

                        await Bot.SendTextMessageAsync(
                            message.Chat.Id,
                            builder.ToString());
                        break;
                    }
                case "/AgendaInfDia":
                    {
                        await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

                        var previousAlert = Alerts.FirstOrDefault(x => x.UserName == message.Chat.Username);
                        previousAlert?.Dispose();

                        var timeOfAlert = message.Text.Split(' ').ElementAtOrDefault(1);
                        if (string.IsNullOrWhiteSpace(timeOfAlert) || !timeOfAlert.Contains(":"))
                        {
                            await Bot.SendTextMessageAsync(
                                message.Chat.Id,
                                "Invalid hour input, use hour:min format");
                            break;
                        }

                        try
                        {
                            var timeSplit = timeOfAlert.Split(':');
                            var hour = Convert.ToInt32(timeSplit[0]);
                            var min = Convert.ToInt32(timeSplit[1]);
                            Alerts.Add(new OncePerDayTimer(new TimeSpan(hour, min, 0), () => GetInfoOfTheDay(message.Chat.Username, message.Chat.Id.ToString())));

                            await Bot.SendTextMessageAsync(
                                message.Chat.Id,
                                $"Alert saved to {hour} : {min} ");
                        }
                        catch (Exception)
                        {
                            await Bot.SendTextMessageAsync(
                                message.Chat.Id,
                                "Invalid hour input, use hour:min format");
                        }

                        break;
                    }
                case "/FeriadosMes":
                    {
                        var inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("1","/FeriadosMes 1"),
                                InlineKeyboardButton.WithCallbackData("2","/FeriadosMes 2"),
                                InlineKeyboardButton.WithCallbackData("3","/FeriadosMes 3"),
                                InlineKeyboardButton.WithCallbackData("4","/FeriadosMes 4"),
                                InlineKeyboardButton.WithCallbackData("5","/FeriadosMes 5"),
                                InlineKeyboardButton.WithCallbackData("6","/FeriadosMes 6")
                            },
                            new []
                            {
                                InlineKeyboardButton.WithCallbackData("7","/FeriadosMes 7"),
                                InlineKeyboardButton.WithCallbackData("8","/FeriadosMes 8"),
                                InlineKeyboardButton.WithCallbackData("9","/FeriadosMes 9"),
                                InlineKeyboardButton.WithCallbackData("10","/FeriadosMes 10"),
                                InlineKeyboardButton.WithCallbackData("11","/FeriadosMes 11"),
                                InlineKeyboardButton.WithCallbackData("12","/FeriadosMes 12")
                            }
                        });

                        await Bot.SendTextMessageAsync(message.Chat.Id, "Choose the month", replyMarkup: inlineKeyboard);

                        break;
                    }
                case "/ListarEventosAgendaMensal":
                    {
                        var inlineKeyboard = new InlineKeyboardMarkup(new[]
                        {
                        new []
                        {
                            InlineKeyboardButton.WithCallbackData("1","/ListarEventosAgendaMensal 1"),
                            InlineKeyboardButton.WithCallbackData("2","/ListarEventosAgendaMensal 2"),
                            InlineKeyboardButton.WithCallbackData("3","/ListarEventosAgendaMensal 3"),
                            InlineKeyboardButton.WithCallbackData("4","/ListarEventosAgendaMensal 4"),
                            InlineKeyboardButton.WithCallbackData("5","/ListarEventosAgendaMensal 5"),
                            InlineKeyboardButton.WithCallbackData("6","/ListarEventosAgendaMensal 6")
                        },
                        new []
                        {
                            InlineKeyboardButton.WithCallbackData("7","/ListarEventosAgendaMensal 7"),
                            InlineKeyboardButton.WithCallbackData("8","/ListarEventosAgendaMensal 8"),
                            InlineKeyboardButton.WithCallbackData("9","/ListarEventosAgendaMensal 9"),
                            InlineKeyboardButton.WithCallbackData("10","/ListarEventosAgendaMensal 10"),
                            InlineKeyboardButton.WithCallbackData("11","/ListarEventosAgendaMensal 11"),
                            InlineKeyboardButton.WithCallbackData("12","/ListarEventosAgendaMensal 12")
                        }
                    });

                        await Bot.SendTextMessageAsync(message.Chat.Id, "Choose the month", replyMarkup: inlineKeyboard);
                        break;
                    }
                case "/CriarEvento":
                    {
                        var infos = message.Text.Replace("/CriarEvento", string.Empty).Split('-');
                        var convertOk = DateTime.TryParse(infos.ElementAtOrDefault(0), out var startdate);
                        if (!convertOk)
                        {
                            await Bot.SendTextMessageAsync(message.Chat.Id, "Invalid start date input, use dd/mm/yyyy hh:mm:ss format");
                            break;
                        }

                        convertOk = DateTime.TryParse(infos.ElementAtOrDefault(1), out var endDate);
                        if (!convertOk)
                        {
                            await Bot.SendTextMessageAsync(message.Chat.Id, "Invalid end date input, use dd/mm/yyyy hh:mm:ss format");
                            break;
                        }

                        var title = infos.ElementAtOrDefault(2)?.Trim();
                        if (string.IsNullOrWhiteSpace(title))
                        {
                            await Bot.SendTextMessageAsync(message.Chat.Id, "Title is empty");
                            break;
                        }

                        var userCalendar = Service.GetById(message.Chat.Username) ?? new CalendarOfEvents();
                        userCalendar.OwnerUserName = message.Chat.Username;
                        userCalendar.Events.Add(new EventScheduled
                        {
                            Description = title,
                            Title = title,
                            StartDate = startdate,
                            EndDate = endDate,
                        });

                        Service.Update(userCalendar);

                        await Bot.SendTextMessageAsync(message.Chat.Id, $"Event created -> {startdate:g} - {endDate:g} - {title}");

                        break;
                    }
                default:
                    {
                        Console.WriteLine(@"Erro");
                        break;
                    }

            }
        }

        public static async void GetInfoOfTheDay(string userName, string chatId)
        {
            var builder = new StringBuilder();
            builder.AppendLine($"This is your daily events of {DateTime.Now:d}");

            var userCalendar = Service.GetById(userName);
            var dailyEvents = userCalendar?.Events.Where(x => x.StartDate.ToShortDateString() == DateTime.Now.ToShortDateString());

            if (dailyEvents != null)
            {
                foreach (var @event in dailyEvents)
                {
                    builder.AppendLine($"{@event.StartDate:g} - {@event.EndDate:g} => {@event.Title}");
                }

            }

            await Bot.SendTextMessageAsync(chatId, builder.ToString());
        }
    }
}
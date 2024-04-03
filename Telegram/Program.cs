using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram
{
    class Program
    {
        private static string token = "Telegram bot token";
        private static TelegramBotClient client;
        private static bool sessionActive;

        static void Main(string[] args)
        {
            client = new TelegramBotClient(token);
            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            Console.ReadLine();
            client.StopReceiving();
        }

        private static async void OnMessageHandler(object? sender, MessageEventArgs e)
        {
            var message = e.Message;

            if (message.Text != null)
            {
                if (message.Text == "/start")
                {
                    sessionActive = true;
                    var sticker1 = await client.SendStickerAsync(
                            chatId: message.Chat.Id,
                            sticker: "CAACAgEAAxkBAAEBHBFlCKkI3T917UTF8H6vRMmzWV2E_AACQwEAAkLykEWy8gKvi7lDCDAE",
                            replyToMessageId: message.MessageId
                            );
                    await client.SendTextMessageAsync(message.Chat.Id,
                        "I am the Kosh, I'll help you as much as I can!\nYou should use the buttons for interaction with me!!!",
                        replyMarkup: GetButtons(sessionActive));
                }
                switch (message.Text)
                {
                    case "Hiii, Kosh!":
                        var sticker1 = await client.SendStickerAsync(
                            chatId: message.Chat.Id,
                            sticker: "CAACAgEAAxkBAAEBHA1lCKdhtt-q83tLb5dRZfjvHjJj0gAC7gIAAkUikEUl753otX8sSzAE",
                            replyToMessageId: message.MessageId
                            );
                        message.Text = "Meow meow meow!";
                        await client.SendTextMessageAsync(
                            message.Chat.Id,
                            message.Text,
                            replyMarkup: GetButtons(sessionActive));
                        break;
                    case "Schedule":
                        string[] koshes = { "Name1", "Name2", "Name3" };
                        DateTime today = DateTime.Now;

                        for (int i = 0; i < 7; i++)
                        {
                            int personIndex = i % 3;
                            string dayOfWeek = today.DayOfWeek.ToString();
                            Console.WriteLine($"{today:dd.MM.yyyy} ({dayOfWeek}): {koshes[personIndex]}");
                            today = today.AddDays(1);
                        }
                        today = DateTime.Now;

                        DateTime yesterdayDate = DateTime.Now.AddDays(-1);
                        DateTime todayDate = DateTime.Now;
                        DateTime tomorrowDate = DateTime.Now.AddDays(1);

                        string yesterday = $"{yesterdayDate:dd.MM.yyyy}  {yesterdayDate.DayOfWeek}: {koshes[(int)yesterdayDate.DayOfWeek % 3]}";
                        string todayKosh = $"{todayDate:dd.MM.yyyy}  {todayDate.DayOfWeek}: {koshes[(int)todayDate.DayOfWeek % 3]}";
                        string tomorrow = $"{tomorrowDate:dd.MM.yyyy}  {tomorrowDate.DayOfWeek}: {koshes[(int)tomorrowDate.DayOfWeek % 3]}";

                        var sticker6 = await client.SendStickerAsync(
                            chatId: message.Chat.Id,
                            sticker: "CAACAgEAAxkBAAEBHEZlCLx8uY2EhC13nzfzlVjabzvtcQACGQIAAjFikUWpDAL4CEAkMjAE",
                            replyToMessageId: message.MessageId);
                        message.Text = $"Dear {koshes[(int)todayDate.DayOfWeek % 3]}, I am so sorry for you today, but that is life)\n\nDishwashing schedule:\n" +
                            $"{yesterday}\n{todayKosh}\n{tomorrow}";
                        await client.SendTextMessageAsync(message.Chat.Id,
                            message.Text, replyToMessageId: message.MessageId,
                            replyMarkup: GetButtons(sessionActive));
                        break;
                    case "Where is Kosh???":
                        var sticker2 = await client.SendStickerAsync(
                            chatId: message.Chat.Id,
                            sticker: "CAACAgEAAxkBAAEBHBNlCKqlZSRiyfownoZ37SS4fNTKYwAC7QAD8yaQRTv7RSLsScgSMAQ",
                            replyToMessageId: message.MessageId
                            );
                        await client.SendTextMessageAsync(message.Chat.Id,
                            "Excuse meeeee, I am here!!!",
                            replyMarkup: GetButtons(sessionActive));
                        break;
                    case "See you, Kosh!":
                        sessionActive = false;
                        var sticker3 = await client.SendStickerAsync(
                           chatId: message.Chat.Id,
                           sticker: "CAACAgEAAxkBAAEBHBVlCKt_Dk_-Bo5dPeGaMRBNy7mCNgACswEAAhuLkUUkc0s3N5I97DAE",
                           replyToMessageId: message.MessageId
                           );
                        await client.SendTextMessageAsync(message.Chat.Id,
                            "See you, but you ditched me!!!",
                            replyMarkup: GetButtons(sessionActive));
                        break;
                    case "Start":
                        sessionActive = true;
                        var sticker4 = await client.SendStickerAsync(
                           chatId: message.Chat.Id,
                           sticker: "CAACAgEAAxkBAAEBHEhlCL6HrTk8ST9peS8ZaKiP_TyS0AAC1gEAAjTekUU9YQuUTlBcJzAE",
                           replyToMessageId: message.MessageId
                           );
                        await client.SendTextMessageAsync(message.Chat.Id,
                            "Welcome Back!",
                            replyMarkup: GetButtons(sessionActive));
                        break;
                    case "/start":
                        break;
                    default:
                        var sticker5 = await client.SendStickerAsync(
                            chatId: message.Chat.Id,
                            sticker: "CAACAgEAAxkBAAEBHCNlCLGekG65Z6jbPxiLzoOQYqDj0gACcwEAAk1jkUUo74Erd7RLZjAE",
                            replyToMessageId: message.MessageId
                            );
                        await client.SendTextMessageAsync(message.Chat.Id,
                            "I am the Koshhh, Idk this command, use your paws to click on buttons!",
                            replyMarkup: GetButtons(sessionActive));
                        break;
                }
            }
        }

        private static IReplyMarkup GetButtons(bool sessionActive)
        {
            if (sessionActive == true)
            {
                return new ReplyKeyboardMarkup
                {
                    Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Hiii, Kosh!" }, new KeyboardButton { Text = "Schedule" } },
                    new List<KeyboardButton> { new KeyboardButton { Text = "Where is Kosh???" }, new KeyboardButton { Text = "See you, Kosh!" } }
                }
                };
            }
            else
            {
                return new ReplyKeyboardMarkup
                {
                    Keyboard = new List<List<KeyboardButton>>
                    {
                        new List<KeyboardButton> { new KeyboardButton { Text = "Start" } }
                    }
                };
            }
        }
    }
}

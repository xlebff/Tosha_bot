using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.ReplyMarkups;
using System.Data.SQLite;
using System.Data;

namespace ConsoleApp1
{
    internal class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("6551377323:AAGiaoNV_i68slzrrLdquP2S2mHfob_rXlU");

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;

                switch (message.Text)
                {
                    case "/start":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("1"))
                            {
                                Keyboard = new KeyboardButton[][]
                                {
                       new KeyboardButton[] { "Студент" },
                       new KeyboardButton[] { "Преподаватель" }
                                },
                                ResizeKeyboard = true,
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Чтобы я мог подстроить алгоритм работы именно под Ваши потребности, укажите преподаватель👩‍🏫 Вы, или студент🧑‍🎓",
                                replyMarkup: keyboard);

                            break;
                        }

                    case "Студент":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("1"))
                            {
                                Keyboard = new KeyboardButton[][]
                                {
                       new KeyboardButton[] { "ИС-11", "ИС-12" },
                       new KeyboardButton[] { "ИС-13", "ИС-14" }
                                },
                                ResizeKeyboard = true,
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Отлично!👍\r\nТеперь можете выбрать свою группу🖇",
                                replyMarkup: keyboard);
                            break;
                        }

                    case "ИС-11":
                    case "ИС-12":
                    case "ИС-13":
                    case "ИС-14":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("1"))
                            {
                                Keyboard = new KeyboardButton[][]
                                {
                       new KeyboardButton[] { "Административные центры", "Расписание звонков"  },
                       new KeyboardButton[] { "Расписание преподавателей", "Расписание группы" },
                       new KeyboardButton[] { "Получить материалы к урокам" }
                                },
                                ResizeKeyboard = true,
                            };

                            string connectionString = String.Format("Data Source=test.db");
                            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                            {
                                connection.Open();
                                try
                                {
                                    SQLiteCommand command = new SQLiteCommand(connection);

                                    command.CommandText = $"insert into UsersInfo(Username) values('{message.Text}')";
                                    command.ExecuteNonQuery();
                                    connection.Close();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"Failed to open {ex.Message}");
                                }
                            }

                            await botClient.SendTextMessageAsync(
                chatId: message.Chat.Id,
                text: "Супер!❤️‍🔥\r\nМожете ознакомиться с полезными возможностями🔎",
                replyMarkup: keyboard);
                            break;
                        }

                    case "Административные центры":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("1"))
                            {
                                Keyboard = new KeyboardButton[][]
                                {
                       new KeyboardButton[] { "Бухгалтерия", "Кафедра"  },
                       new KeyboardButton[] { "Библиотека", "Юридический отдел" },
                       new KeyboardButton[] { "Заочное отделение", "Очное отделение" },
                       new KeyboardButton[] { "Учебная часть", "Медпункт" },
                       new KeyboardButton[] { "Отдел кадров", "Отдел охраны труда и безопасности" }
                                },
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Понятно!👍\r\n\r\nКакое именно отделение вас интересует?🤔",
                                replyMarkup: keyboard);
                            break;
                        }
                    case "Бухгалтерия":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Бухгалтерия работает с 🖨:\r\n\r\n 9:00 до 12:00\r\n\r\n\U0001f9c7Перерыв на обед\U0001f95e \r\n\r\n13:00 до 17:00\r\n\r\nНа 1⃣ этаже в 3⃣ кабинете",
                                replyMarkup: keyboard);
                            break;
                        }
                    case "Кафедра":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Кафедра работает с 📚:\r\n\r\n8:00 до 12:40\r\n\r\n\U0001f95eПерерыв на обед\U0001f9c7\r\n\r\n13:00 до 17:00\r\n\r\nНа 1⃣ этаже во 2⃣ кабинете",
                                replyMarkup: keyboard);
                            break;
                        }
                    case "Медпункт":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Медпункт работает с 💊:\r\n\r\n7:45 до 12:40\r\n\r\n\U0001f9c7Перерыв на обед\U0001f95e\r\n\r\n13:00 до 17:00\r\n\r\nНа 1⃣ этаже в 1⃣ кабинете",
                                replyMarkup: keyboard);
                            break;
                        }
                    case "Библиотека":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Библиотека работает с 📕:\r\n\r\n10:00 до 13:00\r\n\r\n\U0001f95eПерерыв на обед\U0001f9c7\r\n\r\n13:20 до 16:00\r\n\r\nНа 1⃣ этаже в 4⃣ кабинете",
                                replyMarkup: keyboard);
                            break;
                        }
                    case "Отдел кадров":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Отдел кадров работает с 📑:\r\n\r\n8:00 до 12:00\r\n\r\n\U0001f9c7Перерыв на обед\U0001f95e\r\n\r\n13:00 до 17:00 \r\n\r\nНа 2⃣ этаже в 3⃣ кабинете",
                                replyMarkup: keyboard);
                            break;
                        }
                    case "Учебная часть":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Учебная часть работает с 📖:\r\n\r\n8:00 до 12:00\r\n\r\n\U0001f9c7Перерыв на обед\U0001f95e\r\n\r\n13:00 до 17:00 \r\n\r\nНа 2⃣ этаже в 2⃣ кабинете",
                                replyMarkup: keyboard);
                            break;
                        }
                    case "Отдел охраны труда и безопасности":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Отдел охраны труда и безопасности работает с ⚔:\r\n\r\n8:00 до 12:00\r\n\r\n\U0001f9c7Перерыв на обед\U0001f95e\r\n\r\n13:00 до 17:00 \r\n\r\nНа 2⃣ этаже в 1⃣ кабинете",
                                replyMarkup: keyboard);
                            break;
                        }
                    case "Заочное отделение":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Заочное отделение работает с 🔒:\r\n\r\n8:00 до 12:00\r\n\r\n\U0001f9c7Перерыв на обед\U0001f95e\r\n\r\n13:00 до 17:00 \r\n\r\nНа 2⃣ этаже в 4⃣ кабинете",
                                replyMarkup: keyboard);
                            break;
                        }
                    case "Очное отделение":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Очное отделение работает с 🔐:\r\n\r\n8:00 до 12:00\r\n\r\n\U0001f9c7Перерыв на обед\U0001f95e\r\n\r\n13:00 до 17:00 \r\n\r\nНа 3⃣ этаже в 1⃣ кабинете",
                                replyMarkup: keyboard);
                            break;
                        }
                    case "Юридический отдел":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Юридический отдел работает с 📊:\r\n\r\n8:00 до 12:00\r\n\r\n\U0001f9c7Перерыв на обед\U0001f95e\r\n\r\n13:00 до 17:00 \r\n\r\nНа 3⃣ этаже в 2⃣ кабинете",
                                replyMarkup: keyboard);
                            break;
                        }

                    case "Назад":
                        {
                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("1"))
                            {
                                Keyboard = new KeyboardButton[][]
                                {
                       new KeyboardButton[] { "Студент" },
                       new KeyboardButton[] { "Преподаватель" }
                                },
                                ResizeKeyboard = true,
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Чтобы я мог подстроить алгоритм работы именно под Ваши потребности, укажите преподаватель👩‍🏫 Вы, или студент🧑‍🎓",
                                replyMarkup: keyboard);
                            break;
                        }

                    case "Расписание группы":
                        {
                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("1"))
                            {
                                Keyboard = new KeyboardButton[][]
                                {
                       new KeyboardButton[] { "На неделю" },
                       new KeyboardButton[] { "На сегодня", "На завтра" }
                                },
                                ResizeKeyboard = true,
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Расписание на какой период Вы хотите посмотреть?",
                                replyMarkup: keyboard);
                            break;
                        }
                    case "На неделю":
                        {
                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Расписание группы 🐲:\r\n\r\n27 октября, пятница\r\n08:00 — 09:30\r\nФизика\r\nТроилина В.С., ауд. 103-1\r\n\r\n09:40 — 11:10\r\nХимия\r\nХайлова Л.В., ауд. 404-1\r\n\r\n11:30 — 13:00\r\nОсновы безопасности жизнедеятельности\r\nНещадим К.С., ауд. 324-1\r\n\r\n13:10 — 14:40\r\nДоп. занятие\r\nДжалагония М.Ш., ауд. 323-1\r\n\r\n28 октября, суббота\r\n08:00 — 09:30\r\nГеография\r\nВидинеева Е.А., ауд. 213-1\r\n\r\n09:40 — 11:10\r\nФизическая культура\r\nКорбан С.Н., ауд. с/з2-1\r\n\r\n11:30 — 13:00\r\nРусский язык\r\nРожченко Т.В., ауд. 310-1",
                                replyMarkup: keyboard);
                            break;
                        }
                    case "На сегодня":
                        {
                            DateTime date = DateTime.Today;

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Расписание группы 🐲:\r\n\r\n" + date + "\r\n08:00 — 09:30\r\nФизика\r\nТроилина В.С., ауд. 103-1\r\n\r\n09:40 — 11:10\r\nХимия\r\nХайлова Л.В., ауд. 404-1\r\n\r\n11:30 — 13:00\r\nОсновы безопасности жизнедеятельности\r\nНещадим К.С., ауд. 324-1\r\n\r\n13:10 — 14:40\r\nДоп. занятие\r\nДжалагония М.Ш., ауд. 323-1\r\n\r\n",
                                replyMarkup: keyboard);
                            break;
                        }
                    case "На завтра":
                        {
                            DateTime date = DateTime.Today.AddDays(1);

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Расписание группы 🐲:\r\n\r\n" + date + "\r\n08:00 — 09:30\r\nФизика\r\nТроилина В.С., ауд. 103-1\r\n\r\n09:40 — 11:10\r\nХимия\r\nХайлова Л.В., ауд. 404-1\r\n\r\n11:30 — 13:00\r\nОсновы безопасности жизнедеятельности\r\nНещадим К.С., ауд. 324-1\r\n\r\n13:10 — 14:40\r\nДоп. занятие\r\nДжалагония М.Ш., ауд. 323-1\r\n\r\n",
                                replyMarkup: keyboard);
                            break;
                        }

                    case "Расписание преподавателей":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("1"))
                            {
                                Keyboard = new KeyboardButton[][]
                                {
                                     new KeyboardButton[] { "Иванов Иван Иванович", "Петров Пётр Петрович" }
                                },
                                ResizeKeyboard = true,
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Круто!\U0001faa9\r\nРасписание какого преподавателя Вас интересует?\U0001f9d1‍🏫",
                    
                                replyMarkup: keyboard);
                            break;
                        }
                    case "Иванов Иван Иванович":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "У Иванова Ивана Ивановича👤:\r\n\r\n27 октября, пятница\r\n08:00 — 09:30\r\nИстория\r\nИС-11, ауд. 217-1\r\n\r\n09:40 — 11:10\r\nИстория\r\nИС-12, ауд. 217-1\r\n\r\n11:30 — 13:00\r\nИстория\r\nСА-21, ауд. 217-1\r\n\r\n28 октября, суббота\r\n08:00 — 09:30\r\nИстория\r\nСА-11, ауд. 217-1\r\n\r\n09:40 — 11:10\r\nИстория\r\nИС-12, ауд. 217-1\r\n\r\n11:30 — 13:00\r\nИстория\r\nИС-11, ауд. 217-1\r\n\r\n13:10 — 14:40\r\nИстория\r\nСА-22, ауд. 217-1",
                                replyMarkup: keyboard);
                            break;
                        }
                    case "Петров Пётр Петрович":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "У Петрова Пётра Петровича👤:\r\n\r\n27 октября, пятница\r\n08:00 — 09:30\r\nИстория\r\nИС-11, ауд. 217-1\r\n\r\n09:40 — 11:10\r\nИстория" +
                                "\r\nИС-12, ауд. 217-1\r\n\r\n11:30 — 13:00\r\nИстория\r\nСА-21, ауд. 217-1\r\n\r\n28 октября, суббота\r\n08:00 — 09:30\r\nИстория\r\n" +
                                "СА-11, ауд. 217-1\r\n\r\n09:40 — 11:10\r\nИстория\r\nИС-12, ауд. 217-1\r\n\r\n11:30 — 13:00\r\nИстория\r\nИС-11, ауд. 217-1\r\n\r\n" +
                                "13:10 — 14:40\r\nИстория\r\nСА-22, ауд. 217-1",
                                replyMarkup: keyboard);
                            break;
                        }

                    case "Расписание звонков":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "🔔Расписание звонков🔔\r\n\r\n🖋С учётом классных часов🖋:\r\n1 пара:\r\n8:00-9:30\r\n2 пара:\r\n9:40-11-10\r\n\r\n" +
                                "🎊Большая перемена🎊\r\n\r\n3 пара:\r\n11:30-13:00\r\n\r\n\U0001f9f7Классный час\U0001f9f7:\r\n13:05-14:05\r\n\r\n4 пара:\r\n" +
                                "14:10-15:40\r\n\r\n🎊Большая перемена🎊\r\n\r\n\r\n5 пара:\r\n16:00-17:30\r\n6 пара:\r\n17:40-19:10\r\n\r\n\r\n✒️Без учёта классных часов✒️:" +
                                "\r\n1 пара:\r\n8:00-9:30\r\n2 пара:\r\n9:40-11:10\r\n\r\n🎊Большая перемена🎊\r\n\r\n3 пара:\r\n11:30-13:00\r\n4 пара:\r\n13:10-14:40" +
                                "\r\n \r\n🎊Большая перемена🎊\r\n\r\n5 пара:\r\n15:00-16:30\r\n6 пара:\r\n16:40-18:10\r\n7 пара:\r\n18:20-19:50",
                                replyMarkup: keyboard);
                            break;
                        }

                    case "Получить материалы к урокам":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Ой-ой\U0001fae2\r\nКажется у нас произошли технические шоколадки 🍫.\r\nЯ уже занимаюсь их устранением, зайдите позже\U0001f9f9",
                                replyMarkup: keyboard);
                            break;
                        }
                    case "Загрузить материалы к урокам":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Ой-ой\U0001fae2\r\nКажется у нас произошли технические шоколадки 🍫.\r\nЯ уже занимаюсь их устранением, зайдите позже\U0001f9f9",
                                replyMarkup: keyboard);
                            break;
                        }

                    case "Преподаватель":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("1"))
                            {
                                Keyboard = new KeyboardButton[][]
                                {
                       new KeyboardButton[] { "Административные центры", "Расписание звонков" },
                       new KeyboardButton[] { "Расписание", "Загрузить материалы к урокам", "Заявления для преподавателей" }
                                },
                                ResizeKeyboard = true,
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Супер!❤️‍🔥\r\nМожете ознакомиться с полезными возможностями🔎",
                                replyMarkup: keyboard);
                            break;
                        }

                    case "Расписание":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "08:00 — 09:30\r\nИстория\r\nИС-11, ауд. 217-1\r\n\r\n09:40 — 11:10\r\nИстория" +
                                "\r\nИС-12, ауд. 217-1\r\n\r\n11:30 — 13:00\r\nИстория\r\nСА-21, ауд. 217-1\r\n\r\n28 октября, суббота\r\n08:00 — 09:30\r\nИстория\r\n" +
                                "СА-11, ауд. 217-1\r\n\r\n09:40 — 11:10\r\nИстория\r\nИС-12, ауд. 217-1\r\n\r\n11:30 — 13:00\r\nИстория\r\nИС-11, ауд. 217-1\r\n\r\n" +
                                "13:10 — 14:40\r\nИстория\r\nСА-22, ауд. 217-1",
                                replyMarkup: keyboard);
                            break;
                        }

                    case "Заявления для преподавателей":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("1"))
                            {
                                Keyboard = new KeyboardButton[][]
                                {
                       new KeyboardButton[] { "Увольнение", "Приём на работу" },
                       new KeyboardButton[] { "Перенос пар" }
                                },
                                ResizeKeyboard = true,
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Обрабатываю запрос...👌\r\nВыберете нужное заявление!👇",
                                replyMarkup: keyboard);
                            break;
                        }
                    case "Увольнение":
                    case "Приём на работу":
                    case "Поступление":
                    case "Заявление об отсутствии на парах":
                    case "Вступлении в профсоюз":
                    case "Перенос пар":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Назад"))
                            {
                                ResizeKeyboard = true
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Ой-ой\U0001fae2\r\nКажется у нас произошли технические шоколадки 🍫.\r\nЯ уже занимаюсь их устранением, зайдите позже\U0001f9f9",
                                replyMarkup: keyboard);
                            break;
                        }

                    case "Заявления для студентов":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("1"))
                            {
                                Keyboard = new KeyboardButton[][]
                                {
                       new KeyboardButton[] { "Поступление", "Заявление об отсутствии на парах" },
                       new KeyboardButton[] { "Вступлении в профсоюз" }
                                },
                                ResizeKeyboard = true,
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Обрабатываю запрос...👌\r\nВыберете нужное заявление!👇",
                                replyMarkup: keyboard);
                            break;
                        }

                    case "Анекдот":
                        {
                            Console.WriteLine($"Received a text message in chat {message.Chat.Id}.");

                            string[] joke = { "\U0001f923 АНЕКДОТ \U0001f923\r\n\r\nНа экзамене. \r\nПрофессор: \r\n" +
                                    "Вы трое, прекратите передавать друг другу записки!\r\nСтудент: \r\nЭто не записки, " +
                                    "это мы в преферанс играем.\r\nНу, тогда извините.", "\U0001f923 АНЕКДОТ \U0001f923\r\n\r\n" +
                                    "У нас на факультете училась девушка по фамилии Капустина. На третьем курсе она вышла замуж, " +
                                    "однако новую фамилию успешно скрывала. В конце года на стенде информации вывесили оценки по " +
                                    "одному из предметов, и тогда весь курс узнал, что студентка Капустина теперь Кочан", "\U0001f923 " +
                                    "АНЕКДОТ \U0001f923\r\n\r\nСтуденты знают, что самый вытаскиваемый билет на экзаменах - \"не тот\"", 
                                "\U0001f923 АНЕКДОТ \U0001f923\r\n\r\nСтудентка приезжает домой на каникулы и кричит с порога: - Мама, " +
                                "а у меня теперь есть мальчик! - Радость моя, и где он учится? - Ты что, ему всего два месяца!", 
                                "\U0001f923 АНЕКДОТ \U0001f923\r\n\r\nСтудентам, поступившим на философский факультет, уже на первой " +
                                "лекции объясняют, где поблизости находятся магазины \"Красное и белое\".", "\U0001f923 АНЕКДОТ " +
                                "\U0001f923\r\n\r\nСамая большая студенческая ложь: \"Список использованной литературы\".", "\U0001f923 " +
                                "АНЕКДОТ \U0001f923\r\n\r\nИногда, если промолчать, будешь казаться умнее.\r\nЭто не тот случай, отвечайте " +
                                "на билет", "\U0001f923 АНЕКДОТ \U0001f923\r\n\r\nВыходит студент из аудитории. Товарищи спрашивают:\r\nНу что, " +
                                "сдал?\r\nКажется, сдал.\r\nА что спрашивали?\r\nА черт его знает - препод ведь спрашивал на английском",
                                "\U0001f923 АНЕКДОТ \U0001f923\r\n\r\nДля тех студентов, кто не ходит на первые пары, потому что рано вставать " +
                                "неохота, сообщаем, что в армии подъем в 6:00", "\U0001f923 АНЕКДОТ \U0001f923\r\n\r\nОтличительная черта студента: " +
                                "не знал, но вспомнил!", "\U0001f923 АНЕКДОТ \U0001f923\r\n\r\nНет никого старше, чем выпускник, и никого моложе, чем первокурсник" };
                            int random = new Random().Next(0, joke.Length-1);

                            var keyboard = new ReplyKeyboardMarkup(new KeyboardButton("1"))
                            {
                                Keyboard = new KeyboardButton[][]
                                {
                       new KeyboardButton[] { "Анекдот" },
                       new KeyboardButton[] { "Назад" }
                                },
                                ResizeKeyboard = true,
                            };

                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: joke[random],
                                replyMarkup: keyboard);
                            break;
                        }

                    case "/help":
                        {
                            await botClient.SendTextMessageAsync(
                                chatId: message.Chat.Id,
                                text: "Нужна помощь? Сейчас объясню!👍\r\n\r\nУ Вас на выбор есть 2 кнопочки🖲️. " +
                                "Каждая из них представляет определенную группу пользователей👥. Выбирая ту, которая " +
                                "нужна именно Вам, Вы сможете ознакомиться с моими функциями и найти интересующую информацию💻!");
                            break;
                        }
                }
            }
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { },
            };
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken
            );
            Console.ReadLine();
        }
    }
}
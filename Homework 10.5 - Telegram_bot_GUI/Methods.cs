using System;
using System.Collections.Generic;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Xml.Linq;
using System.Linq;
using System.Windows.Controls;
using System.Threading.Tasks;

namespace Homework_10._5___Telegram_bot_GUI
{
    public class Methods
    {
        public static ListBox LS;
        public static Button but1;
        public static List<string> GetExchangeRates()
        {
            
            var res = new List<string>();

            WebClient client = new WebClient();
            var xml = client.DownloadString("https://www.cbr-xml-daily.ru/daily.xml");
            XDocument xdoc = XDocument.Parse(xml);
            var el = xdoc.Element("ValCurs").Elements("Valute");
            string dollar = el.Where(x => x.Attribute("ID").Value == "R01235").Select(x => x.Element("Value").Value).FirstOrDefault();
            string eur = el.Where(x => x.Attribute("ID").Value == "R01239").Select(x => x.Element("Value").Value).FirstOrDefault();
            
            res.Add($"USD: {dollar}");
            res.Add($"EUR: {eur}");

            return res;
        }

        public static void PrintList(List<string> list)
        {
            foreach (var e in list)
            {
                Console.WriteLine(e);
            }
        }

        public static void WriteListToFile(List<string> list, string filepath)
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText(filepath, json);
            Console.WriteLine($"Файл {filepath} создан");
        }

        [Obsolete]
        public static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {

                //MessageBox.Show($"$Пришло сообщение с текстом: { msg.Text} от { msg.Chat.FirstName} { msg.Chat.LastName}");

                await Task.Run(() =>
                {
                        
                        but1.Dispatcher.Invoke((Action)(() =>
                        {
                            LS.Items.Add($"Пришло сообщение: {msg.Text} от {msg.Chat.FirstName} {msg.Chat.LastName}");
                        }));
                        Thread.Sleep(1000);
                });


                Globals.Currencylist1 = GetExchangeRates();

                switch (msg.Text)
                {
                    case "/start":
                        await Globals.Client.SendTextMessageAsync(msg.Chat.Id, "Добро пожаловать на канал о курсах валют", replyMarkup: GetButtons());
                        break;

                    case Globals.menuItem1:
                        await Globals.Client.SendTextMessageAsync(msg.Chat.Id, Globals.menuItem1, replyMarkup: GetButtons());

                        foreach (var item in Globals.Currencylist1)
                        {
                            await Globals.Client.SendTextMessageAsync(msg.Chat.Id, item, replyMarkup: GetButtons());
                            Thread.Sleep(10);
                        }

                        break;

                    case Globals.menuItem2:
                        WriteListToFile(Globals.Currencylist1, Globals.Filepath);

                        using (var sendFileStream = File.Open(Globals.Filepath, FileMode.Open))
                        {
                            await Globals.Client.SendDocumentAsync(msg.Chat.Id, new Telegram.Bot.Types.InputFiles.InputOnlineFile(sendFileStream, Globals.Filepath));
                        }

                        await Globals.Client.SendTextMessageAsync(msg.Chat.Id, $"Файл {Globals.Filepath} загружен", replyMarkup: GetButtons());

                        break;

                    default:
                        await Globals.Client.SendTextMessageAsync(msg.Chat.Id, "Выберите действие", replyMarkup: GetButtons());
                        break;
                }
            }
        }

        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton>{new KeyboardButton { Text = Globals.menuItem1 }, new KeyboardButton { Text = Globals.menuItem2 } },
                    //new List<KeyboardButton>{new KeyboardButton { Text = Globals.menuItem3 }, new KeyboardButton { Text = Globals.menuItem4 } }
                }
            };
        }
    }
}

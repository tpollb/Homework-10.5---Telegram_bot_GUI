using System;
using System.Collections.Generic;
using Telegram.Bot;

namespace Homework_10._5___Telegram_bot_GUI
{
    internal class Globals
    {
        private static string token = "";
        public static string Token { get => token; set => token = value; }

        private static TelegramBotClient client;
        public static TelegramBotClient Client { get => client; set => client = value; }

        private static List<string> Currencylist = new List<string>();
        public static List<string> Currencylist1 { get => Currencylist; set => Currencylist = value; }

        private static string filepath = $"Курсы валют на {DateTime.Now.ToShortDateString()}.json";
        public static string Filepath { get => filepath; set => filepath = value; }

        public const string menuItem1 = "Вывести курсы на экран";
        public const string menuItem2 = "Получить json файл курсов";
        public const string menuItem3 = "кнопка";
        public const string menuItem4 = "кнопка";
    }
}

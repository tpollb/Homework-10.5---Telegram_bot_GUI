using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;


namespace Homework_10._5___Telegram_bot_GUI
{
    /// <summary>
    /// Логика взаимодействия для Bot_Id_Window.xaml
    /// </summary>
    public partial class Bot_Id_Window : Window
    {
        public Bot_Id_Window()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Globals.Token = TextBoxId.Text;
            MessageBox.Show(Globals.Token);

            Globals.Client = new TelegramBotClient(Globals.Token);

            Globals.Client.StartReceiving();

            Globals.Client.OnMessage += Methods.OnMessageHandler;

            Thread.Sleep(1000);

            Globals.Client.StopReceiving();
        }
    }
}

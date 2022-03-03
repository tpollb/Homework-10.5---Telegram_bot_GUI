using System;
using System.Windows;
using System.Windows.Controls;
using Telegram.Bot;

namespace Homework_10._5___Telegram_bot_GUI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        [Obsolete]
        private void StopBotButtonButton_Click(object sender, RoutedEventArgs e)
        {
            Globals.Client.StopReceiving();

            MsgListBox.Items.Add("Bot stoped");

            StopBotButton.IsEnabled = false;
        }

        [Obsolete]
        private void StartBotButton_Click(object sender, RoutedEventArgs e)
        {
            Globals.Client = new TelegramBotClient(Globals.Token);

            Globals.Client.StartReceiving();

            Globals.Client.OnMessage += Methods.OnMessageHandler;

            StopBotButton.IsEnabled = true; 

            MsgListBox.Items.Add("Bot started");
        }
    }
}

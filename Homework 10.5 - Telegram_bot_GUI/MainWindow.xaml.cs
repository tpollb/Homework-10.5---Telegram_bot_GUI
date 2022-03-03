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

            StartBotButton.IsEnabled = true;

            Bot_Id_Button.IsEnabled = true;
        }

        [Obsolete]
        private void StartBotButton_Click(object sender, RoutedEventArgs e)
        {
            Globals.Client = new TelegramBotClient(Globals.Token);

            Globals.Client.StartReceiving();

            StartBotButton.IsEnabled = false;

            Bot_Id_Button.IsEnabled = false;

            StopBotButton.IsEnabled = true;

            MsgListBox.Items.Add("Bot started");

            Globals.Client.OnMessage += Methods.OnMessageHandler;

            Methods.but1 = this.StartBotButton;
            Methods.LS = this.MsgListBox;
        }

        private void Bot_Id_Button_Click(object sender, RoutedEventArgs e)
        {
            Bot_Id_Window bot_Id_Window = new Bot_Id_Window();  
            bot_Id_Window.Show();
            bot_Id_Window.but1 = this.StartBotButton;
        }
    }
}

using System;
using System.Windows;
using System.Windows.Controls;

namespace Homework_10._5___Telegram_bot_GUI
{
    /// <summary>
    /// Логика взаимодействия для Bot_Id_Window.xaml
    /// </summary>
    public partial class Bot_Id_Window : Window
    {
        public Button but1;
        public Bot_Id_Window()
        {
            InitializeComponent();
        }

        [Obsolete]
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Globals.Token = TextBoxId.Text;
            this.Close();
            but1.IsEnabled = true;
        }
    }
}

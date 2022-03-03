using System;
using System.Windows;


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
            this.Close();   
            MainWindow mainWindow = new MainWindow();
            mainWindow.Visibility = Visibility.Visible;
        }
    }
}

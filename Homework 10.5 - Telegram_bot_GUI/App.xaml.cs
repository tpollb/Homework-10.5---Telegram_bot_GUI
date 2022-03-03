using System.Windows;

namespace Homework_10._5___Telegram_bot_GUI
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Bot_Id_Window w = new Bot_Id_Window();
            w.Show();  
        }
    }
}

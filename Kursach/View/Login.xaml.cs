using System.Windows;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>

    public partial class Login : Window
    {
        private MainWindow the_window;

        public Login(MainWindow window)
        {
            InitializeComponent();
            the_window = window;

        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            if(LoginText.Text == "root" && PasswordText.Password == "Dragon2012")
            {
                Invalid_info.Text = "Успешный вход";              
                this.Close();
                the_window.Show();
            }
            else
            {
                Invalid_info.Text = "Введен неверный логин/пароль";
            }

         
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            the_window.Close();
        }
    }
}

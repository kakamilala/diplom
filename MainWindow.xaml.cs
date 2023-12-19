using System.Windows;

namespace alimak
{
    public partial class MainWindow : Window
    {
        private Emploee user = new Emploee();
        private string userlogin;
        private string userpass;

        public MainWindow()
        {
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userlogin = login.Text;
            userpass = password.Password;
            if (userlogin == "")
                MessageBox.Show("Введите логин!");
            else if (userpass == "")
                MessageBox.Show("Введите пароль!");

            else if (user.IsEmpExist(userlogin, userpass))
            {
                authorization.Visibility = Visibility.Hidden;
                Menu menu = new Menu(user, this);
                content.Children.Add(menu);
            }
            else
                MessageBox.Show("Пользователь не найден!\nПопробуйте еще раз!", "Ошибка");
        }
    }
}

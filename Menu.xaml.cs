using System.Windows;
using System.Windows.Controls;

namespace alimak
{
    /// <summary>
    /// Логика взаимодействия для Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        public Emploee user = new Emploee();
        private MainWindow window;
        public Menu()
        {
            InitializeComponent();
        }
        public Menu(Emploee user, MainWindow mainWindow)
        {
            InitializeComponent();
            this.user = user;
            window = mainWindow;

            if (user.Position == "Начальник цеха")
            {
                EmploeesButton.Visibility = Visibility.Hidden;
                ReportsButton.Visibility = Visibility.Hidden;
                DepartmentssButton.Visibility = Visibility.Hidden;
            }
            if (user.Position == "Главный инженер")
            {
                EmploeesButton.Visibility = Visibility.Hidden;
                ReportsButton.Visibility = Visibility.Hidden;
                DepartmentssButton.Visibility = Visibility.Hidden;
            }
            if (user.Position == "Заместитель директора")
            {
                ReportsButton.Visibility = Visibility.Hidden;
            }


        }

        private void ProjectsButton_Click(object sender, RoutedEventArgs e)
        {
            Projects projects = new Projects(this);
            content.Children.Add(projects);
        }

        private void TimetableButton_Click(object sender, RoutedEventArgs e)
        {
            Timetable timetable = new Timetable(this, "");
            content.Children.Add(timetable);
        }

        private void EmploeesButton_Click(object sender, RoutedEventArgs e)
        {
            Emploees emploees = new Emploees(this);
            content.Children.Add(emploees);
        }

        //private void ReportsButton_Click(object sender, RoutedEventArgs e)
        //{
        //    Reports reports = new Reports();
        //    content.Children.Add(reports);
        //}

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            window.authorization.Visibility = Visibility.Visible;

            window.login.Clear();
            window.password.Clear();
            this.Visibility = Visibility.Collapsed;
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            EmploeeInfo emploeeInfo = new EmploeeInfo(user, this);
            emploeeInfo.DeleteEmpButton.Visibility = Visibility.Collapsed;
            emploeeInfo.ChangeEmpButton.Visibility = Visibility.Collapsed;
            emploeeInfo.password.Text = "********";
            content.Children.Add(emploeeInfo);
        }

        private void DepartmentssButton_Click(object sender, RoutedEventArgs e)
        {
            Departments departments = new Departments(this);
            content.Children.Add(departments);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace alimak
{
    /// <summary>
    /// Логика взаимодействия для EmploeeInfo.xaml
    /// </summary>
    public partial class EmploeeInfo : UserControl
    {
        private Emploee emploee = new Emploee();
        private Menu menu = new Menu();
        public EmploeeInfo()
        {
            InitializeComponent();
        }
        public EmploeeInfo(Emploee emploee, Menu menu)
        {
            InitializeComponent();
            this.emploee = emploee;
            this.menu = menu;
            fio.Text = emploee.FIO;
            position.Text = emploee.Position;
            birthday.Text += emploee.Birthday;
            phone.Text = emploee.Phone;
            gender.Text = emploee.Gender;
            email.Text = emploee.Email;
            login.Text = emploee.Login;
            password.Text = "********";

            if(menu.user.Position!="Заместитель директора")
            {
                ChangeEmpButton.Visibility = Visibility.Hidden;
                DeleteEmpButton.Visibility = Visibility.Hidden;
            }

        }

        private void DeleteEmpButton_Click(object sender, RoutedEventArgs e)
        {
            if(emploee.RemoveEmp())
            {
                MessageBox.Show("Сотрудник удален!");
                Emploees emploees = new Emploees(menu);
                menu.content.Children.Add(emploees);
            }
            else
                MessageBox.Show("Ошибка!");
        }

        private void ChangeEmpButton_Click(object sender, RoutedEventArgs e)
        {
            AddEmploee addEmploee = new AddEmploee(menu, emploee);
            addEmploee.title.Text = "Изменить данные";
            addEmploee.SaveEmploeeButton.Visibility = Visibility.Visible;

            addEmploee.fio.Text = emploee.FIO;
            addEmploee.position.Text = emploee.Position;
            addEmploee.date.Text += emploee.Birthday;
            addEmploee.phone.Text = emploee.Phone;
            addEmploee.gender.Text = emploee.Gender;
            addEmploee.email.Text = emploee.Email;
            addEmploee.login.Text = emploee.Login;
            addEmploee.password.Text = emploee.Password;

            menu.content.Children.Add(addEmploee);
        }
    }
}

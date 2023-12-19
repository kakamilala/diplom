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
    /// Логика взаимодействия для AddEmploee.xaml
    /// </summary>
    public partial class AddEmploee : UserControl
    {
        Emploee emploee = new Emploee();
        private Menu menu = new Menu();

        private List<Department> departmentList = new List<Department>();
        private DBSQL dBSQL = new DBSQL();

        public AddEmploee(Menu menu, int iduser)
        {
            InitializeComponent();
            this.menu = menu;
            emploee.Id = iduser;
        }
        public AddEmploee(Menu menu, Emploee emploee)
        {
            InitializeComponent();
            this.menu=menu;
            this.emploee = emploee;


            if (position.Text == "Работник цеха")
            {
                login.IsEnabled = false;
                password.IsEnabled = false;
                iddep.IsEnabled = true;
            }
            else
            {
                login.IsEnabled = true;
                password.IsEnabled = true;
                iddep.IsEnabled = false;
            }
        }

        private void AddEmploeeButton_Click(object sender, RoutedEventArgs e)
        {

            if (fio.Text == "")
                MessageBox.Show("Введите ФИО!");
            else if (date.Text == "")
                MessageBox.Show("Введите дату рождения!");
            else if (gender.Text == "")
                MessageBox.Show("Выберите пол!");
            else if (phone.Text == "")
                MessageBox.Show("Введите номер телефона!");
            else if (email.Text == "")
                MessageBox.Show("Введите email!");
            else if (position.Text == "")
                MessageBox.Show("Выберите должность!");
            else if (login.Text == "" && position.Text != "Работник цеха")
                MessageBox.Show("Введите логин!");
            else if (password.Text == "" && position.Text != "Работник цеха")
                MessageBox.Show("Введите пароль!");
            else if(iddep.Text==""&& position.Text == "Работник цеха")
                MessageBox.Show("Укажите цех!");
            else
            {
                emploee.FIO = fio.Text;
                emploee.Birthday =date.Text;
                emploee.Gender = gender.Text;
                emploee.Phone = phone.Text;
                emploee.Email = email.Text;
                emploee.Position = position.Text;
                emploee.Login = login.Text;
                emploee.Password = password.Text;
                if (iddep.Text != "")
                    emploee.IDdep =Convert.ToInt32(iddep.Text);

                if (emploee.AddEmp())
                {
                    MessageBox.Show("Сотрудник успешно добавлен!");
                    Emploees emploees = new Emploees(menu);
                    menu.content.Children.Add(emploees);
                }
                else
                    MessageBox.Show("Произошла ошибка!");
            }
        }

        private void position_LostFocus(object sender, RoutedEventArgs e)
        {
            if(position.Text=="Работник цеха")
            {
                login.IsEnabled = false;
                password.IsEnabled = false;
                iddep.IsEnabled = true;
            }
            else
            {
                login.IsEnabled = true;
                password.IsEnabled = true;
                iddep.IsEnabled = false;
            }
        }

        private void SaveEmploeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (fio.Text == "")
                MessageBox.Show("Введите ФИО!");
            else if (date.Text == "")
                MessageBox.Show("Введите дату рождения!");
            else if (gender.Text == "")
                MessageBox.Show("Выберите пол!");
            else if (phone.Text == "")
                MessageBox.Show("Введите номер телефона!");
            else if (email.Text == "")
                MessageBox.Show("Введите email!");
            else if (position.Text == "")
                MessageBox.Show("Выберите должность!");
            else if (login.Text == "" && position.Text != "Работник цеха")
                MessageBox.Show("Введите логин!");
            else if (password.Text == "" && position.Text != "Работник цеха")
                MessageBox.Show("Введите пароль!");
            else if (iddep.Text == "" && position.Text == "Работник цеха")
                MessageBox.Show("Укажите цех!");
            else
            {
                emploee.FIO = fio.Text;
                emploee.Birthday = date.Text;
                emploee.Gender = gender.Text;
                emploee.Phone = phone.Text;
                emploee.Email = email.Text;
                emploee.Position = position.Text;
                emploee.Login = login.Text;
                emploee.Password = password.Text;
                if(iddep.Text !="")
                    emploee.IDdep = Convert.ToInt32(iddep.Text);

                if (emploee.ChangeEmp())
                {
                    MessageBox.Show("Данные изменены!");
                }
                else
                    MessageBox.Show("Произошла ошибка!");

                if(emploee.Position== "Работник цеха")
                {
                    if(emploee.ChangeDep())
                        MessageBox.Show("Данные изменены!");
                    else
                        MessageBox.Show("Произошла ошибка!");
                }
            }
                
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            departmentList = dBSQL.AllDepartments();
            iddep.ItemsSource = departmentList;
        }
    }
}

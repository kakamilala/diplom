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
using System.Windows.Shapes;

namespace alimak
{
    /// <summary>
    /// Логика взаимодействия для AddDepartment.xaml
    /// </summary>
    public partial class AddDepartment : Window
    {
        private DBSQL DBSQL= new DBSQL();
        private List<Department> DepartmentList = new List<Department>();
        private List<Emploee> Emploes = new List<Emploee>();
        private Department department=new Department();
        public AddDepartment(Menu menu)
        {
            InitializeComponent();

        }



        private void AddDepButton_Click(object sender, RoutedEventArgs e)
        {
            if (iddep.Text == "")
                MessageBox.Show("Введите номер цеха!");
            else if(!int.TryParse(iddep.Text, out int id))
                MessageBox.Show("Некорректный ввод!");
            else
            {
                bool f = false;
                for (int i = 0; i < DepartmentList.Count; i++)
                {
                    if (DepartmentList[i].IDdep == Convert.ToInt32(iddep.Text))
                    {
                        MessageBox.Show("Такой цех уже существует!");
                        f = false;
                    }
                    else
                        f = true;

                }

                if (f)
                {
                    department.IDdep = Convert.ToInt32(iddep.Text);
                    for (int i = 0; i < Emploes.Count; i++)
                    {
                        if (user.Text == Emploes[i].FIO)
                            department.IDuser = Emploes[i].Id;
                    }

                    if (department.AddDep())
                    {
                        MessageBox.Show("Цех успешно добавлен!");
                        this.Close();
                    }
                    else
                        MessageBox.Show("Произошла ошибка!");
                }
            }
            
        }


        private void ChangeDepButton_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < Emploes.Count; i++)
            {
                if (user.Text == Emploes[i].FIO)
                    department.IDuser = Emploes[i].Id;
            }
            if (department.ChangeDep())
            {
                MessageBox.Show("Изменения сохранены!");
            }
            else
                MessageBox.Show("Произошла ошибка!");
        }

        private void RemoveDepButton_Click(object sender, RoutedEventArgs e)
        {
            if (department.RemoveDep())
            {
                MessageBox.Show("Цех удален!");
                this.Close();
            }
            else
                MessageBox.Show("Произошла ошибка!");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DepartmentList = DBSQL.AllDepartments();
            Emploes = DBSQL.AllEmpNach();
            if (iddep.Text != "")
                department.IDdep = Convert.ToInt32(iddep.Text);
            if (user.Text != "")
            {
                for (int i = 0; i < Emploes.Count; i++)
                {
                    if (user.Text == Emploes[i].FIO)
                        department.IDuser = Emploes[i].Id;
                }
            }
            user.ItemsSource = Emploes;
        }
    }
}

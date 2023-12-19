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
    /// Логика взаимодействия для AddProject.xaml
    /// </summary>
    public partial class AddProject : UserControl
    {
        private Menu menu=new Menu();
        private List<Department> departmentList = new List<Department>();
        private List<Product> productlist = new List<Product>();
        private List<string> productlistinproject = new List<string>();
        private DBSQL dBSQL = new DBSQL();
        private Project project = new Project();

        public AddProject(Menu menu, int i)
        {
            InitializeComponent();
            this.menu=menu;
            project.Id = i;

            
        }

       

        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            if (name.Text == "")
                MessageBox.Show("Введите название!");
            else if (date.Text == "")
                MessageBox.Show("Выберите дату!");
            else if (Convert.ToDateTime(date.Text) <= dateTime)
                MessageBox.Show("Некорректная дата!");
            else if (iddep.Text == "")
                MessageBox.Show("Выберите цех!");
            else if (cost.Text == "")
                MessageBox.Show("Введите стоимость!");
            else if (!int.TryParse(cost.Text, out int num))
                MessageBox.Show("Некорректная стоимость");
            else if (email.Text == "")
                MessageBox.Show("Введите эл.почту!");
            else if (products.Items.Count==0)
                MessageBox.Show("Выберите продукцию!");
            else
            {
                project.Name = name.Text;
                project.Date = date.Text;
                project.DepartmentNumber = Convert.ToInt32(iddep.Text);
                project.Cost = Convert.ToInt32(cost.Text);
                project.Description = description.Text;
                project.Status = "на утверждении";
                project.Email = email.Text;
                project.Products = productlistinproject;

                if (project.AddProject())
                    MessageBox.Show("Проект успешно добавлен!");
                else
                    MessageBox.Show("Произошла ошибка!");

                Projects projects = new Projects(menu);
                menu.content.Children.Add(projects);
            }


            
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            if ((chooseProduct.SelectedItem as Product).Name != "")
            {
                if (!products.Items.Contains((chooseProduct.SelectedItem as Product).Name))
                {
                    productlistinproject.Add((chooseProduct.SelectedItem as Product).Name);
                    products.Items.Add((chooseProduct.SelectedItem as Product).Name);
                }
                else
                    MessageBox.Show("Этот элемент уже добавлен!");
            }

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            departmentList = dBSQL.AllDepartments();
            iddep.ItemsSource = departmentList;

            productlist = dBSQL.AllProducts();
            chooseProduct.ItemsSource = productlist;
        }

        private void productitem_GotFocus(object sender, RoutedEventArgs e)
        {
            //for(int i=0; i<productlist.Count; i++)
            //{
            //    if()
            //}
        }
    }
}

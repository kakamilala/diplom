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
    /// Логика взаимодействия для Account.xaml
    /// </summary>
    public partial class Departments: UserControl
    {
        private DBSQL DBSQL = new DBSQL();
        private List<Department> departmentsWithDW = new List<Department>();
        private Menu menu=new Menu();

        public Departments(Menu menu)
        {
            InitializeComponent();

            this.menu = menu;
            

            if (menu.user.Position =="Заместитель директора")
                AddDepButton.Visibility=Visibility.Visible;
            
        }

        private void AddDepButton_Click(object sender, RoutedEventArgs e)
        {
            AddDepartment addDepartment=new AddDepartment(menu);
            addDepartment.ChangeDepButton.Visibility = Visibility.Hidden;
            addDepartment.RemoveDepButton.Visibility = Visibility.Hidden;
            addDepartment.Show();
        }


        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(menu.user.Position =="Заместитель директора")
            {
                int index = this.DepContainer.SelectedIndex;

                if (index != System.Windows.Forms.ListBox.NoMatches)
                {
                    AddDepartment addDepartment = new AddDepartment(menu);
                    addDepartment.AddDepButton.Visibility = Visibility.Hidden;
                    addDepartment.iddep.Text = departmentsWithDW[index].IDdep.ToString();
                    addDepartment.iddep.IsEnabled = false;
                    addDepartment.user.Text = departmentsWithDW[index].FIO;
                    addDepartment.title.Text = "Цех";
                    addDepartment.Show();
                }
            }
            
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            departmentsWithDW = DBSQL.AllDepartmentWithDepWorkers();

            DepContainer.ItemsSource = departmentsWithDW;
        }
    }
}

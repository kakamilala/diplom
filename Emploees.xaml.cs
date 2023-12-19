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
    /// Логика взаимодействия для Emploees.xaml
    /// </summary>
    public partial class Emploees : UserControl
    {
        private DBSQL DBSQL = new DBSQL();
        private List<Emploee> emploees= new List<Emploee>();
        private Menu menu = new Menu();
        public Emploees(Menu menu)
        {
            InitializeComponent();
            this.menu = menu;
            if(menu.user.Position=="Заместитель директора")
                AddEmploee.Visibility= Visibility.Visible;

           

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int j = Convert.ToInt32(((TextBlock)sender).Tag);
            EmploeeInfo emploeeInfo = new EmploeeInfo(emploees[j], menu);
            menu.content.Children.Add(emploeeInfo);
        }

        private void searchtext_GotFocus(object sender, RoutedEventArgs e)
        {
            if (searchtext.Text == "Поиск")
                searchtext.Clear();

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            EmpContainer.Items.Clear();
            emploees.Clear();
            emploees = DBSQL.SearchEmploees(searchtext.Text);


            for (int i = 0; i < emploees.Count; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = emploees[i].FIO;
                textBlock.Tag = i;
                textBlock.MouseLeftButtonDown += new MouseButtonEventHandler(Button_Click);
                EmpContainer.Items.Add(textBlock);
            }
        }

        private void AddEmploee_Click(object sender, RoutedEventArgs e)
        {
            int iduser = emploees[emploees.Count-1].Id+1;
            AddEmploee addEmploee = new AddEmploee(menu, iduser);
            menu.content.Children.Add(addEmploee);
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            emploees = DBSQL.AllEmploees();


            for (int i = 0; i < emploees.Count; i++)
            {
                TextBlock textBlock = new TextBlock();
                textBlock.Text = emploees[i].FIO;
                textBlock.Tag = i;
                textBlock.MouseLeftButtonDown += new MouseButtonEventHandler(Button_Click);
                EmpContainer.Items.Add(textBlock);
            }
        }
    }
}

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
    /// Логика взаимодействия для Projects.xaml
    /// </summary>
    public partial class Projects : UserControl
    {
        private DBSQL DBSQL = new DBSQL();
        private List<Project> projects=new List<Project>();
        private List<Project> _projects=new List<Project>();
        
        Menu menu = new Menu();
        public Projects(Menu menu)
        {
            InitializeComponent();
            this.menu = menu;

            

        }

        private void FilterProjects()
        {
            for (int i = 0; i < _projects.Count; i++)
            {
                if (_projects[i].Status == "на утверждении")
                    projects.Add(_projects[i]);
            }
            for (int i = 0; i < _projects.Count; i++)
            {
                if (_projects[i].Status == "утвержден")
                    projects.Add(_projects[i]);
            }
            for (int i = 0; i < _projects.Count; i++)
            {
                if (_projects[i].Status == "в работе")
                    projects.Add(_projects[i]);
            }
            for (int i = 0; i < _projects.Count; i++)
            {
                if (_projects[i].Status == "выполнен")
                    projects.Add(_projects[i]);
            }
            for (int i = 0; i < _projects.Count; i++)
            {
                if (_projects[i].Status == "отклонен")
                    projects.Add(_projects[i]);
            }
           
        }

        private void ProjectColors()
        {
            for (int i = 0; i < projects.Count; i++)
            {
                shablonProj textBlock = new shablonProj();
                textBlock.name.Text = projects[i].Name;
                textBlock.status.Text = projects[i].Status;


                switch (textBlock.status.Text)
                {
                    case "выполнен":
                        textBlock.status.Foreground = Brushes.Green;
                        break;
                    case "отклонен":
                        textBlock.status.Foreground = Brushes.Gray;
                        break;
                    case "в работе":
                        textBlock.status.Foreground = Brushes.Red;
                        break;
                    case "на утверждении":
                        textBlock.status.Foreground = Brushes.Orange;
                        break;
                    case "утвержден":
                        textBlock.status.Foreground = Brushes.Blue;
                        break;
                }
                textBlock.Tag = i;
                textBlock.MouseLeftButtonDown += new MouseButtonEventHandler(Button_Click);
                ProjContainer.Items.Add(textBlock);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int j = Convert.ToInt32(((shablonProj)sender).Tag);
            ProjectInfo projectInfo = new ProjectInfo(projects[j], menu);
            menu.content.Children.Add(projectInfo);
        }

        private void searchtext_GotFocus(object sender, RoutedEventArgs e)
        {
            if (searchtext.Text == "Поиск")
                searchtext.Clear();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            ProjContainer.Items.Clear();
            ProjContainer.Items.Clear();

            projects.Clear();

            projects = DBSQL.SearchProjects(searchtext.Text);

            ProjectColors();

        }

        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            if(_projects.Count>0)
            {
                AddProject addProject = new AddProject(menu, _projects[_projects.Count - 1].Id + 1);
                menu.content.Children.Add(addProject);
            }
            else
            {
                AddProject addProject = new AddProject(menu, 1);
                menu.content.Children.Add(addProject);
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            _projects = DBSQL.AllProjects();


            if (menu.user.Position == "Заместитель директора")
                AddProjectButton.Visibility = Visibility.Visible;

            FilterProjects();

            if (menu.user.Position == "Начальник цеха")
            {
                for (int i = 0; i < _projects.Count; i++)
                {
                    if (projects[i].DepartmentNumber == menu.user.IDdep)
                        projects.Remove(projects[i]);
                }
            }

            ProjectColors();
        }
    }
}

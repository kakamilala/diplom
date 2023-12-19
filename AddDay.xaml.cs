using System;
using System.Collections.Generic;
using System.Windows;

namespace alimak
{
    /// <summary>
    /// Логика взаимодействия для AddDay.xaml
    /// </summary>
    public partial class AddDay : Window
    {
        private Project project = new Project();
        private List<Task> tasklist = new List<Task>();
        private DBSQL DBSQL = new DBSQL();
        public AddDay(Project project)
        {
            InitializeComponent();
            this.project = project;
        }

        private void AddDayButton_Click(object sender, RoutedEventArgs e)
        {
            if (task.Text != "")
            {
                int idtask = 0, iduser = 0;
                DateTime _date;
                for (int i = 0; i < tasklist.Count; i++)
                {
                    if (tasklist[i].Description == task.Text)
                    {
                        idtask = tasklist[i].IDtask;
                        iduser = tasklist[i].IDuser;
                    }
                }
                _date = Convert.ToDateTime(date.Text);



                if (DBSQL.AddDay(iduser, _date, idtask))
                {
                    MessageBox.Show("Успешно!");
                    this.Close();
                }
                else
                    MessageBox.Show("Ошибка!");
            }
            else
                MessageBox.Show("Выберите задачу!");



        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            tasklist = DBSQL.AllTasks(project);
            task.ItemsSource = tasklist;
        }
    }
}

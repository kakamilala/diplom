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
    /// Логика взаимодействия для Timetable.xaml
    /// </summary>
    public partial class Timetable : UserControl
    {
        private Menu menu = new Menu();
        private List<Project> projects=new List<Project>();
        private List<TimetableDay> timetable=new List<TimetableDay>();
        private List<shablonTask> tasklist = new List<shablonTask>();
        private DBSQL DBSQL=new DBSQL();

        public Timetable(Menu menu, string name)
        {
            InitializeComponent();
            this.menu = menu;
            CB.Text = name;

            if (menu.user.Position == "Главный инженер")
            {
                label.Visibility = Visibility.Visible;
                chooselabel.Visibility = Visibility.Visible; 
            }
        }



        private void searchtext_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CB.Text == "Поиск")
                CB.Text="";
        }
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {

            Timetable timetable = new Timetable(menu, CB.Text);
            menu.content.Children.Add(timetable);

        }

        private void Task_Click(object sender, RoutedEventArgs e)
        {
            if (menu.user.Position == "Главный инженер")
            {
                int j = Convert.ToInt32(((shablonTask)sender).Tag);
                MessageBoxButton messageBoxButton = MessageBoxButton.YesNo;
                MessageBoxResult messageBoxResult;
                messageBoxResult = MessageBox.Show("Удалить задачу в этот день?", "Удаление задачи", messageBoxButton);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    if (DBSQL.RemoveDay(timetable[j].ID))
                    {
                        MessageBox.Show("Задача удалена!");
                        timetable.Remove(timetable[j]);
                    }
                    else
                        MessageBox.Show("Ошибка!");
                }
            }

        }


        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime dateTime = DateTime.Now.Date;
            if(menu.user.Position=="Главный инженер")
            {
                for (int j = 0; j < projects.Count; j++)
                {
                    if (projects[j].Name == CB.Text&&projects[j].Status=="в работе")
                    {
                        if (calendar.SelectedDate.Value <= Convert.ToDateTime(projects[j].Date) && calendar.SelectedDate.Value >= dateTime)
                        {
                            AddDay addDay = new AddDay(projects[j]);
                            addDay.date.Text = Convert.ToString(calendar.SelectedDate.Value.ToShortDateString());
                            addDay.Show();
                        }
                        else
                            MessageBox.Show("Выбранная дата не входит в допустимый диапазон:\n" + dateTime.ToShortDateString() + " - " + Convert.ToDateTime(projects[j].Date).ToShortDateString());
                        

                    }
                }
            }        
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            projects = DBSQL.AllProjects();
            CB.ItemsSource = projects;

            if (CB.Text!="")
            {
                for (int j = 0; j < projects.Count; j++)
                {
                    if (projects[j].Name == CB.Text)
                    {
                        timetable = DBSQL.SearchTimetable(projects[j].Id);
                        for (int i = 0; i < timetable.Count; i++)
                        {

                            shablonTask shablonTask = new shablonTask();
                            shablonTask.date.Text = Convert.ToString(timetable[i].Date.ToShortDateString());
                            shablonTask.name.Text = timetable[i].Description;
                            shablonTask.fio.Text = timetable[i].FIO;
                            shablonTask.status.Text = timetable[i].Status;
                            shablonTask.Tag = i;
                            shablonTask.MouseLeftButtonDown += new MouseButtonEventHandler(Task_Click);

                            tasks.Items.Add(shablonTask);
                        }
                    }
                }
            }
            
        }
    }
}

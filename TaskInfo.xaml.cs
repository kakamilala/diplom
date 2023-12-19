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
    /// Логика взаимодействия для TaskInfo.xaml
    /// </summary>
    public partial class TaskInfo : Window
    {
        private Menu menu=new Menu();
        private List<Task> Tasks = new List<Task>();
        private Task task=new Task();
        private List<Emploee> emploes = new List<Emploee>();
        private DBSQL dBSQL = new DBSQL();

        public TaskInfo(Menu menu, Task task, List<Task> Tasks)
        {
            InitializeComponent();
            this.menu = menu;
            this.task = task;
            this.Tasks = Tasks;

            
        }

        //private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (AddTasks.tasks.Items.Remove(task.Description))
        //    {
        //        MessageBox.Show("Задача удалена.");
        //        this.Close();
        //    }
        //    else
        //        MessageBox.Show("Ошибка!");


        //}

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            description.Text = task.Description;
            emploes = dBSQL.AllEmploees();
            for (int i = 0; i < emploes.Count; i++)
            {
                if (emploes[i].Id == task.IDuser)
                {
                    user.Text = emploes[i].FIO;
                }
            }
        }
    }
}

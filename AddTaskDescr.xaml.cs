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
    /// Логика взаимодействия для AddTaskDescr.xaml
    /// </summary>
    public partial class AddTaskDescr : Window
    {
        AddTasks addTasks = new AddTasks();
        Task task=new Task();
        DBSQL dBSQL = new DBSQL();
        List<Emploee> emploes = new List<Emploee>();
        List<Emploee> _emploes = new List<Emploee>();


        public AddTaskDescr(AddTasks addTasks)
        {
            InitializeComponent();
            this.addTasks = addTasks;
            
            
        }

        private void SaveTaskButton_Click(object sender, RoutedEventArgs e)
        {
            if(description.Text=="")
                MessageBox.Show("Введите описание задачи!");
            else if(user.Text=="")
                MessageBox.Show("Выберите исполнителя!");
            else
            {
                task.Description = description.Text;
                task.IDproject = addTasks.project.Id;
                task.Status = "новая";
                for (int i = 0; i < emploes.Count; i++)
                {
                    if (emploes[i].FIO == user.Text)
                    {
                        task.IDuser = emploes[i].Id;
                    }
                }

                addTasks.tasklist.Add(task);
                addTasks.ShowTask(task);
                this.Close();
            }
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            _emploes = dBSQL.AllEmploees();
            for (int i = 0; i < _emploes.Count; i++)
            {
                if (_emploes[i].Position != "Директор" && _emploes[i].Position != "Заместитель директора")
                {
                    emploes.Add(_emploes[i]);
                }
            }
            user.ItemsSource = emploes;
        }
    }
}

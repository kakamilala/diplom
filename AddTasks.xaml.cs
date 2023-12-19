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
    /// Логика взаимодействия для AddTasks.xaml
    /// </summary>
    public partial class AddTasks : UserControl
    {
        public Menu menu=new Menu();
        public Project project=new Project();
        public List<Task> tasklist=new List<Task>();
        private DBSQL dBSQL=new DBSQL();
        public AddTasks()
        {
            InitializeComponent();
        }
        public AddTasks(Project project, Menu menu)
        {
            InitializeComponent();
            this.project = project;
            this.menu = menu;

            name.Text = project.Name;
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            AddTaskDescr addTaskDescr = new AddTaskDescr(this);
            addTaskDescr.Show();
        }

        private void DoneTasksButton_Click(object sender, RoutedEventArgs e)
        {
            if(tasklist.Count>0)
            {
                if (dBSQL.AddTasks(tasklist))
                {
                    MessageBox.Show("Задачи успешно добавлены!");
                    project.BeginProject();
                }
                else
                {
                    MessageBox.Show("Произошла ошибка!");
                }

                ProjectInfo projectInfo = new ProjectInfo(project, menu);
                menu.content.Children.Add(projectInfo);
            }
            else
                MessageBox.Show("Не добавлено ни одной задачи!");


        }

        public void ShowTask(Task task)
        {
            TextBlock taskTextBlock = new TextBlock();
            taskTextBlock.Text = task.Description;
            for(int i = 0; i < tasklist.Count; i++)
            {
                if(tasklist[i] == task)
                    taskTextBlock.Tag = i;

            }
            taskTextBlock.MouseLeftButtonDown += new MouseButtonEventHandler(TaskClick);
            tasks.Items.Add(taskTextBlock);
        }

        public void TaskClick(object sender, RoutedEventArgs e)
        {
            int j = Convert.ToInt32(((TextBlock)sender).Tag);
            TaskInfo taskInfo = new TaskInfo(menu, tasklist[j], tasklist);
            taskInfo.Show();

        }
    }
}

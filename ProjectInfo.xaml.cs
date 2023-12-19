using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
    /// Логика взаимодействия для ProjectInfo.xaml
    /// </summary>
    public partial class ProjectInfo : UserControl
    {
        DBSQL dBSQL=new DBSQL();
        private Project project=new Project();
        Menu menu = new Menu();
        private List<Task> tasklist = new List<Task>();

        public ProjectInfo(Project project, Menu menu)
        {
            InitializeComponent();
            this.project = project;
            this.menu = menu;

        }

        private void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            project.Report();
        }

        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
            if (project.ApproveProject())
            {
                ApproveButton.Visibility = Visibility.Hidden;
                RejectButton.Visibility = Visibility.Hidden;

                status.Text = project.Status;

                MailAddress mailAddress = new MailAddress("kamilaibr2002@mail.ru", "Компания по производству электроники");
                MailAddress mailAddress1 = new MailAddress(project.Email);
                SmtpClient Smtp = new SmtpClient();
                Smtp.Host = "smtp.mail.ru";
                Smtp.Port = 25;
                Smtp.EnableSsl = true;
                Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                Smtp.UseDefaultCredentials = false;
                Smtp.Credentials = new NetworkCredential(mailAddress.Address, "byyXSz1CMgZXgPStuGe4");
                    MailMessage Message = new MailMessage(mailAddress,mailAddress1);
                    Message.Subject = "Ваш заказ успешно принят!";
                    Message.Body = "Здравствуйте, мы начали выполнять ваш заказ на производство электроники. Ожидайте дальнейших сообщений!";
                    Smtp.Send(Message);
            }
            else
                MessageBox.Show("Не удалось утвердить проект!");
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (project.RejectProject())
            {
                ApproveButton.Visibility = Visibility.Hidden;
                RejectButton.Visibility = Visibility.Hidden;

                status.Text = project.Status;

                MailAddress mailAddress = new MailAddress("kamilaibr2002@mail.ru", "Компания по производству электроники");
                MailAddress mailAddress1 = new MailAddress(project.Email);
                SmtpClient Smtp = new SmtpClient();
                Smtp.Host = "smtp.mail.ru";
                Smtp.Port = 25;
                Smtp.EnableSsl = true;
                Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                Smtp.UseDefaultCredentials = false;
                Smtp.Credentials = new NetworkCredential(mailAddress.Address, "byyXSz1CMgZXgPStuGe4");
                MailMessage Message = new MailMessage(mailAddress, mailAddress1);
                Message.Subject = "Ваш заказ отклонен!";
                Message.Body = "Здравствуйте, к сожалению мы вынуждены отклонить ваш заказ на производство жлектроники. Свяжитесь с заместителем директора для уточнения деталей.";
                Smtp.Send(Message);
            }
            else
                MessageBox.Show("Не удалось отклонить проект!");
        }

        private void TasksAddButton_Click(object sender, RoutedEventArgs e)
        {
            AddTasks addTasks=new AddTasks(project, menu);
            menu.content.Children.Add(addTasks);
        }

        private void ProjectDoneButton_Click(object sender, RoutedEventArgs e)
        {
            bool f = false;
            for(int i=0; i<tasklist.Count; i++)
            {
                if (tasklist[i].Status == "новая")
                {
                    f = false;
                    break;
                }
                else
                    f= true;
            }

            if(f)
            {
                project.DoneProject();
                ProjectDoneButton.Visibility = Visibility.Hidden;
                status.Text = project.Status;
            }
            else
                MessageBox.Show("Не все задачи проекта завершены!");

        }

        private void ProjectRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if(project.RemoveProject())
            {
                MessageBox.Show("Проект " + project.Name + " удален.");
                Projects projects = new Projects(menu);
                menu.content.Children.Add(projects);
            }
            else
                MessageBox.Show("Ошибка!");



        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (menu.user.Position == "Начальник цеха")
            {
                label.Visibility= Visibility.Visible;
                int i = this.tasks.SelectedIndex;

                if (i != System.Windows.Forms.ListBox.NoMatches)
                {
                    MessageBoxButton messageBoxButton = MessageBoxButton.YesNo;
                    MessageBoxResult messageBoxResult;
                    messageBoxResult = MessageBox.Show("Задача выполнена?", "Выполнение задачи", messageBoxButton);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        if(tasklist[i].DoneTask())
                        {
                            ProjectInfo projectInfo = new ProjectInfo(project, menu);
                            menu.content.Children.Add(projectInfo);
                        }
                        else
                        {
                            MessageBox.Show("Ошибка!");
                        }
                    }
                }

                
            }


        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
            idproject.Text += project.Id;
            name.Text += project.Name;
            date.Text += project.Date;
            iddep.Text += project.DepartmentNumber;
            cost.Text += project.Cost;
            status.Text += project.Status;
            description.Text += project.Description;
            email.Text += project.Email;
            products.ItemsSource = project.Products;

            if (project.Status == "в работе" || project.Status == "выполнен")
            {
                tasklist = dBSQL.AllTasks(project);
                tasks.ItemsSource = tasklist;
            }

            if (menu.user.Position == "Директор")
            {
                if (project.Status == "на утверждении")
                {
                    ApproveButton.Visibility = Visibility.Visible;
                    RejectButton.Visibility = Visibility.Visible;
                }
                else if (project.Status == "выполнен")
                    ReportButton.Visibility = Visibility.Visible;
            }
            if (menu.user.Position == "Главный инженер")
            {
                if (project.Status == "утвержден")
                {
                    TasksAddButton.Visibility = Visibility.Visible;
                }
                else if (project.Status == "в работе")
                {
                    ProjectDoneButton.Visibility = Visibility.Visible;
                }

            }

            if (menu.user.Position == "Заместитель директора")
                ProjectRemoveButton.Visibility = Visibility.Visible;
        }
    }
}

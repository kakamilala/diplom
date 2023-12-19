using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alimak
{
    class DBSQL
    {
        private DB db = new DB();
        private List<Emploee> emploees=new List<Emploee>();
        private List<Project> projects = new List<Project>();
        private List<TimetableDay> timetable=new List<TimetableDay>();
        private List<Task> tasks = new List<Task>();
        private List<Department> departments = new List<Department>();
        private List<Department> departmentsWithDW = new List<Department>();
        private List<Product> products=new List<Product>();




        public DBSQL()
        {

        }

        private int IDdepofWorkers(Emploee emploee)
        {
            db.OpenConnection();
            MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM `depworkers` WHERE `iduser`=@iduser", db.GetConnection());
            mySqlCommand.Parameters.AddWithValue("@iduser", emploee.Id);
            MySqlDataReader dataReader1 = mySqlCommand.ExecuteReader();
            dataReader1.Read();
            emploee.IDdep = dataReader1.GetInt32(dataReader1.GetOrdinal("iddepartment"));
            db.CloseConnection();
            return emploee.IDdep;
            
        }

        public List<Emploee> AllEmploees()
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users`", db.GetConnection());
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Emploee emploee = new Emploee();
                emploee.Id = dataReader.GetInt32(dataReader.GetOrdinal("iduser"));
                emploee.FIO = dataReader.GetString(dataReader.GetOrdinal("fio"));
                emploee.Birthday = dataReader.GetDateTime(dataReader.GetOrdinal("birthday")).ToShortDateString();
                emploee.Gender = dataReader.GetString(dataReader.GetOrdinal("gender"));
                emploee.Phone = dataReader.GetString(dataReader.GetOrdinal("phone"));
                emploee.Email = dataReader.GetString(dataReader.GetOrdinal("email"));
                emploee.Position = dataReader.GetString(dataReader.GetOrdinal("position"));
                if(!dataReader.IsDBNull(dataReader.GetOrdinal("login")) && !dataReader.IsDBNull(dataReader.GetOrdinal("password")))
                {
                    emploee.Login = dataReader.GetString(dataReader.GetOrdinal("login"));
                    emploee.Password = dataReader.GetString(dataReader.GetOrdinal("password"));
                }
                else
                {
                    emploee.Login = "";
                    emploee.Password = "";
                }

               
                emploees.Add(emploee);
            }
            db.CloseConnection();

            for(int i = 0; i < emploees.Count; i++)
            {
                if (emploees[i].Position == "Работник цеха")
                {
                    emploees[i].IDdep=IDdepofWorkers(emploees[i]);
                }
            }

            return emploees;
        }

        public List<Emploee> SearchEmploees(string fio)
        {
            db.OpenConnection();
            string sql = string.Format("SELECT * FROM `users` WHERE `fio` LIKE '%{0}%'", fio);
            MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Emploee emploee = new Emploee();
                emploee.Id = dataReader.GetInt32(dataReader.GetOrdinal("iduser"));
                emploee.FIO = dataReader.GetString(dataReader.GetOrdinal("fio"));
                emploee.Birthday = dataReader.GetDateTime(dataReader.GetOrdinal("birthday")).ToShortDateString();
                emploee.Gender = dataReader.GetString(dataReader.GetOrdinal("gender"));
                emploee.Phone = dataReader.GetString(dataReader.GetOrdinal("phone"));
                emploee.Email = dataReader.GetString(dataReader.GetOrdinal("email"));
                emploee.Position = dataReader.GetString(dataReader.GetOrdinal("position"));
                if (!dataReader.IsDBNull(dataReader.GetOrdinal("login")) && !dataReader.IsDBNull(dataReader.GetOrdinal("password")))
                {
                    emploee.Login = dataReader.GetString(dataReader.GetOrdinal("login"));
                    emploee.Password = dataReader.GetString(dataReader.GetOrdinal("password"));
                }
                else
                {
                    emploee.Login = "";
                    emploee.Password = "";
                }
                emploees.Add(emploee);
            }
            db.CloseConnection();
            return emploees;
        }

        private List<string> Products(int idproject)
        {
            List<string> _products = new List<string>();
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `productsofproject` WHERE `idproject`=@idproject", db.GetConnection());
            command.Parameters.AddWithValue("@idproject", idproject);
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                _products.Add(dataReader.GetString(dataReader.GetOrdinal("product")));
            }

            db.CloseConnection();
            return _products;
        }

        public List<Project> AllProjects()
        {
            projects.Clear();
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `projects`", db.GetConnection());
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Project project = new Project();
                project.Id = dataReader.GetInt32(dataReader.GetOrdinal("idproject"));
                project.Name = dataReader.GetString(dataReader.GetOrdinal("name"));
                project.Date = dataReader.GetDateTime(dataReader.GetOrdinal("date")).ToShortDateString();
                project.DepartmentNumber = dataReader.GetInt32(dataReader.GetOrdinal("iddepartment"));
                project.Status = dataReader.GetString(dataReader.GetOrdinal("status"));
                project.Cost = dataReader.GetInt32(dataReader.GetOrdinal("cost"));
                if(!dataReader.IsDBNull(dataReader.GetOrdinal("description")))
                    project.Description = dataReader.GetString(dataReader.GetOrdinal("description"));
                project.Email = dataReader.GetString(dataReader.GetOrdinal("email"));


                projects.Add(project);
            }
            
            db.CloseConnection();

            for(int i = 0; i <projects.Count; i++)
                projects[i].Products = Products(projects[i].Id);

            return projects;
        }

        public List<Project> SearchProjects(string name)
        {
            projects.Clear();
            db.OpenConnection();
            string sql = string.Format("SELECT * FROM `projects` WHERE `name` LIKE '%{0}%'", name);
            MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Project project = new Project();
                project.Id = dataReader.GetInt32(dataReader.GetOrdinal("idproject"));
                project.Name = dataReader.GetString(dataReader.GetOrdinal("name"));
                project.Date = dataReader.GetDateTime(dataReader.GetOrdinal("date")).ToShortDateString();
                project.DepartmentNumber = dataReader.GetInt32(dataReader.GetOrdinal("iddepartment"));
                project.Status = dataReader.GetString(dataReader.GetOrdinal("status"));
                project.Cost = dataReader.GetInt32(dataReader.GetOrdinal("cost"));

                if (!dataReader.IsDBNull(dataReader.GetOrdinal("description")))
                    project.Description = dataReader.GetString(dataReader.GetOrdinal("description"));
                project.Email = dataReader.GetString(dataReader.GetOrdinal("email"));


                projects.Add(project);
            }
            db.CloseConnection();

            for (int i = 0; i < projects.Count; i++)
                projects[i].Products = Products(projects[i].Id);

            return projects;
        }

        public List<TimetableDay> SearchTimetable(int idproject)
        {
            db.OpenConnection();
            string sql = string.Format("SELECT `calendar`.*, `users`.`fio`, `tasks`.`description`, `tasks`.`status` FROM `calendar` JOIN `tasks` ON `calendar`.`idtask`=`tasks`.`idtask` JOIN `projects` ON `tasks`.`idproject`=`projects`.`idproject` JOIN `users` ON `users`.`iduser`=`calendar`.`iduser` WHERE `projects`.`idproject`={0}", idproject);
            MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                TimetableDay timetableDay = new TimetableDay();
                timetableDay.ID = dataReader.GetInt32(dataReader.GetOrdinal("id"));
                timetableDay.IDuser = dataReader.GetInt32(dataReader.GetOrdinal("iduser"));
                timetableDay.Date =Convert.ToDateTime(dataReader.GetDateTime(dataReader.GetOrdinal("date")).ToShortDateString());
                timetableDay.IDtask = dataReader.GetInt32(dataReader.GetOrdinal("idtask"));
                timetableDay.FIO = dataReader.GetString(dataReader.GetOrdinal("fio"));
                timetableDay.Description = dataReader.GetString(dataReader.GetOrdinal("description"));
                timetableDay.Status = dataReader.GetString(dataReader.GetOrdinal("status"));

                timetable.Add(timetableDay);
            }
            db.CloseConnection();
            return timetable;
        }
        
        public bool AddTasks(List<Task> tasks)
        {
            bool f=false;
            for(int i = 0; i < tasks.Count; i++)
            {
                db.OpenConnection();
                MySqlCommand command = new MySqlCommand("INSERT INTO `tasks` VALUES (NULL, @idproject, @description, @status, @iduser)", db.GetConnection());
                command.Parameters.AddWithValue("@idproject", tasks[i].IDproject);
                command.Parameters.AddWithValue("@description", tasks[i].Description);
                command.Parameters.AddWithValue("@status", tasks[i].Status);
                command.Parameters.AddWithValue("@iduser", tasks[i].IDuser);

                if (command.ExecuteNonQuery() > 0)
                {
                    db.CloseConnection();
                    f=true;
                }
                else
                {
                    db.CloseConnection();
                    f=false;
                }
            }
            return f;

        }

        public List<Task> AllTasks(Project project)
        {
            db.OpenConnection();
            string sql = string.Format("SELECT * FROM `tasks` WHERE `idproject`={0}", project.Id);
            MySqlCommand command = new MySqlCommand(sql, db.GetConnection());
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Task task = new Task();
                task.IDtask = dataReader.GetInt32(dataReader.GetOrdinal("idtask"));
                task.Description = dataReader.GetString(dataReader.GetOrdinal("description"));
                task.Status = dataReader.GetString(dataReader.GetOrdinal("status"));
                task.IDproject = dataReader.GetInt32(dataReader.GetOrdinal("idproject"));
                task.IDuser = dataReader.GetInt32(dataReader.GetOrdinal("iduser"));

                tasks.Add(task);
            }
            db.CloseConnection();
            return tasks;
        }

        public List<Department> AllDepartments()
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `departments`", db.GetConnection());
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Department department = new Department();
                department.IDdep = dataReader.GetInt32(dataReader.GetOrdinal("iddepartment"));
                department.IDuser = dataReader.GetInt32(dataReader.GetOrdinal("iduser"));

                departments.Add(department);
            }
            db.CloseConnection();
            return departments;
        }

        public bool AddDay(int iduser, DateTime date, int idtask)
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("INSERT INTO `calendar` VALUES (NULL, @iduser, @date, @idtask)", db.GetConnection());
            command.Parameters.AddWithValue("@iduser", iduser);
            command.Parameters.AddWithValue("@date", date);
            command.Parameters.AddWithValue("@idtask", idtask);
            if (command.ExecuteNonQuery() > 0)
            {
                db.CloseConnection();
                return true;
            }
            else
            {
                db.CloseConnection();
                return false;
            }

        }

        public bool RemoveDay(int id)
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("DELETE FROM `calendar` WHERE `id`=@id", db.GetConnection());
            command.Parameters.Add("@id", MySqlDbType.Int32).Value =id;
            if (command.ExecuteNonQuery() > 0)
            {
                db.CloseConnection();
                return true;
            }
            else
            {
                db.CloseConnection();
                return false;
            }
        }

        public List<Department> AllDepartmentWithDepWorkers()
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT `departments`.*, `users`.`fio` FROM `departments` JOIN `users` ON `users`.`iduser`=`departments`.`iduser` ", db.GetConnection());
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Department department = new Department();
                department.IDdep = dataReader.GetInt32(dataReader.GetOrdinal("iddepartment"));
                department.IDuser = dataReader.GetInt32(dataReader.GetOrdinal("iduser"));
                department.FIO = dataReader.GetString(dataReader.GetOrdinal("fio"));
                department.DeworkersList();

                departmentsWithDW.Add(department);
            }
            db.CloseConnection();
            return departmentsWithDW;
        }

        public List<Emploee> AllEmpNach()
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `position`='Начальник цеха'", db.GetConnection());
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Emploee emploee = new Emploee();
                emploee.Id = dataReader.GetInt32(dataReader.GetOrdinal("iduser"));
                emploee.FIO = dataReader.GetString(dataReader.GetOrdinal("fio"));

                emploees.Add(emploee);
            }
            db.CloseConnection();
            return emploees;
        }

        public List<Product> AllProducts()
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `products`", db.GetConnection());
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                Product product = new Product();
                product.Name = (dataReader.GetString(dataReader.GetOrdinal("name")));
                product.Description = (dataReader.GetString(dataReader.GetOrdinal("description")));
                products.Add(product);

            }
            db.CloseConnection();
            return products;
        }



    }

    
}

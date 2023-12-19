using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alimak
{
    public class Department
    {
        DB db = new DB();
        public int IDdep { get; set; }
        public int IDuser { get; set; }
        public string FIO { get; set; }
        public List<Emploee> Depworkers { get; set; }

        public Department()
        {
            DeworkersList();
        }

        public void DeworkersList()
        {
            Depworkers = new List<Emploee>();
            db.OpenConnection();
            string sql = string.Format("SELECT `users`.* FROM `users` JOIN `depworkers` ON `users`.`iduser`=`depworkers`.`iduser` WHERE `depworkers`.`iddepartment`={0}", IDdep);
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
                Depworkers.Add(emploee);
            }
            db.CloseConnection();
        }

        public bool AddDep()
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("INSERT INTO `departments` VALUES (@iddep, @iduser)", db.GetConnection());
            command.Parameters.AddWithValue("@iduser", IDuser);
            command.Parameters.AddWithValue("@iddep", IDdep);
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
        
        public bool ChangeDep()
        {
            
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE `departments` SET `iduser`=@iduser WHERE `iddepartment`=@iddep", db.GetConnection());
            command.Parameters.AddWithValue("@iduser", IDuser);
            command.Parameters.AddWithValue("@iddep", IDdep);


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

        public bool RemoveDep()
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("DELETE FROM `departments` WHERE `iddepartment`=@iddep", db.GetConnection());
            command.Parameters.Add("@iddep", MySqlDbType.Int32).Value = IDdep;
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
    }
}

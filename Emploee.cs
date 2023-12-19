using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alimak
{
    public class Emploee
    {
        private DB db = new DB();
        
        public int Id { get; set; }
        public string FIO { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int IDdep { get; set; }


        public Emploee()
        {

        }

        public bool IsEmpExist(string login, string password)
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`=@login AND `password`=@password", db.GetConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
            MySqlDataReader dataReader = command.ExecuteReader();
            if(dataReader.HasRows)
            {
                dataReader.Read();
                Id = dataReader.GetInt32(dataReader.GetOrdinal("iduser"));
                FIO = dataReader.GetString(dataReader.GetOrdinal("fio"));
                Birthday =dataReader.GetDateTime(dataReader.GetOrdinal("birthday")).ToShortDateString();
                Gender = dataReader.GetString(dataReader.GetOrdinal("gender"));
                Phone = dataReader.GetString(dataReader.GetOrdinal("phone"));
                Email = dataReader.GetString(dataReader.GetOrdinal("email"));
                Position = dataReader.GetString(dataReader.GetOrdinal("position"));
                Login = dataReader.GetString(dataReader.GetOrdinal("login"));
                Password = dataReader.GetString(dataReader.GetOrdinal("password"));
                db.CloseConnection();

                return true;
            }
            else
            {
                db.CloseConnection();
                return false;
            }


        }

        public bool AddEmp()
        {
            
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` VALUES (@iduser, @fio, @birthday, @gender, @phone, @email, @position, @login, @password)", db.GetConnection());
            command.Parameters.AddWithValue("@iduser", Id);
            command.Parameters.AddWithValue("@fio", FIO);
            command.Parameters.AddWithValue("@birthday", Convert.ToDateTime(Birthday).ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@gender", Gender);
            command.Parameters.AddWithValue("@phone", Phone);
            command.Parameters.AddWithValue("@email", Email);
            command.Parameters.AddWithValue("@position", Position);
            command.Parameters.AddWithValue("@login", Login);
            command.Parameters.AddWithValue("@password", Password);

            

            if (command.ExecuteNonQuery()>0)
            {
                if (Position == "Работник цеха")
                {
                    MySqlCommand mySqlCommand = new MySqlCommand("INSERT INTO `depworkers` VALUES (NULL, @iddep, @iduser)", db.GetConnection());
                    mySqlCommand.Parameters.AddWithValue("@iddep", IDdep);
                    mySqlCommand.Parameters.AddWithValue("@iduser", Id);
                    mySqlCommand.ExecuteNonQuery();
                }
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
            MySqlCommand command = new MySqlCommand("UPDATE `depworkers` SET `iddepartment`=@iddep WHERE `iduser`=@iduser", db.GetConnection());
            command.Parameters.AddWithValue("@iduser", Id);
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

        

        public bool ChangeEmp()
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE `users` SET `fio`=@fio,`birthday`=@birthday,`gender`=@gender,`phone`=@phone,`email`=@email,`position`=@position,`login`=@login,`password`=@password WHERE `iduser`=@iduser", db.GetConnection());
            command.Parameters.AddWithValue("@iduser", Id);
            command.Parameters.AddWithValue("@fio", FIO);
            command.Parameters.AddWithValue("@birthday", Convert.ToDateTime(Birthday).ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@gender", Gender);
            command.Parameters.AddWithValue("@phone", Phone);
            command.Parameters.AddWithValue("@email", Email);
            command.Parameters.AddWithValue("@position", Position);
            command.Parameters.AddWithValue("@login", Login);
            command.Parameters.AddWithValue("@password", Password);

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

        public bool RemoveEmp()
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("DELETE FROM `users` WHERE `iduser`=@iduser", db.GetConnection());
            command.Parameters.Add("@iduser", MySqlDbType.Int32).Value = Id;
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

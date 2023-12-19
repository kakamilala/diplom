using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alimak
{
    public class Task
    {
        private DB db=new DB();
        public int IDtask { get; set; }
        public string Description { get; set; }
        public int IDproject { get; set; }
        public int IDuser { get; set; }
        public string Status { get; set; }

        public Task()
        {

        }

        //public bool RemoveTask()
        //{
        //    db.OpenConnection();
        //    MySqlCommand command = new MySqlCommand("DELETE FROM `tasks` WHERE `idtask`=@idtask", db.GetConnection());
        //    command.Parameters.Add("@idtask", MySqlDbType.Int32).Value = IDtask;
        //    if (command.ExecuteNonQuery() > 0)
        //    {
        //        db.CloseConnection();
        //        return true;
        //    }
        //    else
        //    {
        //        db.CloseConnection();
        //        return false;
        //    }

        //}

        public bool DoneTask()
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE `tasks` SET `status`='выполнена' WHERE `idtask`=@idtask", db.GetConnection());
            command.Parameters.Add("@idtask", MySqlDbType.Int32).Value = IDtask;
            if (command.ExecuteNonQuery() > 0)
            {
                this.Status = "выполнена";
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

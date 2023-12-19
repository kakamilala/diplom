using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alimak
{
    public class TimetableDay
    {
        private DB db=new DB();
        public int ID { get; set; }
        public int IDuser { get; set; }
        public DateTime Date { get; set; }
        public int IDtask { get; set; }
        public string FIO { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public TimetableDay()
        {

        }

        
    }
}

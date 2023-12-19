using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;

namespace alimak
{

    public class Project
    {
        private DB db = new DB();
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public int DepartmentNumber { get; set; }
        public string Status { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public List<string> Products { get; set; }

        public Project()
        {
            
        }

        public bool AddProject()
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("INSERT INTO `projects` VALUES (@idproject, @name, @date, @iddep, @status, @cost, @description, @email)", db.GetConnection());
            command.Parameters.AddWithValue("@idproject", Id);
            command.Parameters.AddWithValue("@name", Name);
            command.Parameters.AddWithValue("@date",Convert.ToDateTime(Date).ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@iddep", DepartmentNumber);
            command.Parameters.AddWithValue("@status", Status);
            command.Parameters.AddWithValue("@cost", Cost);
            command.Parameters.AddWithValue("@description", Description);
            command.Parameters.AddWithValue("@email", Email);


            if (command.ExecuteNonQuery() > 0)
            {
                db.CloseConnection();
                AddProducts();
                return true;
            }
            else
            {
                db.CloseConnection();
                return false;
            }
        }

        private void AddProducts()
        {
            db.OpenConnection();
            for(int i = 0; i < Products.Count; i++)
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO `productsofproject` VALUES (NULL, @idproject, @name)", db.GetConnection());
                command.Parameters.AddWithValue("@name", Products[i]);
                command.Parameters.AddWithValue("@idproject", Id);
                command.ExecuteNonQuery();
            }
            db.CloseConnection();
        }



        public bool RemoveProject()
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("DELETE FROM `projects` WHERE `idproject`=@idproject", db.GetConnection());
            command.Parameters.Add("@idproject", MySqlDbType.Int32).Value = Id;
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

        public bool ApproveProject()
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE `projects` SET `status`='утвержден' WHERE `idproject`=@idproject", db.GetConnection());
            command.Parameters.Add("@idproject", MySqlDbType.Int32).Value=Id;
            if(command.ExecuteNonQuery()>0)
            {
                this.Status = "утвержден";
                db.CloseConnection();
                return true;
            }
            else
            {
                db.CloseConnection();
                return false;
            }
        }

        public bool RejectProject()
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE `projects` SET `status`='отклонен' WHERE `idproject`=@idproject", db.GetConnection());
            command.Parameters.Add("@idproject", MySqlDbType.Int32).Value = Id;
            if (command.ExecuteNonQuery() > 0)
            {
                this.Status = "отклонен";
                db.CloseConnection();
                return true;
            }
            else
            {
                db.CloseConnection();
                return false;
            }
        }

        public void BeginProject()
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE `projects` SET `status`='в работе' WHERE `idproject`=@idproject", db.GetConnection());
            command.Parameters.Add("@idproject", MySqlDbType.Int32).Value = Id;
            if (command.ExecuteNonQuery() > 0)
            {
                this.Status = "в работе";
            }
            db.CloseConnection();
        }

        public void DoneProject()
        {
            db.OpenConnection();
            MySqlCommand command = new MySqlCommand("UPDATE `projects` SET `status`='выполнен' WHERE `idproject`=@idproject", db.GetConnection());
            command.Parameters.Add("@idproject", MySqlDbType.Int32).Value = Id;
            if (command.ExecuteNonQuery() > 0)
            {
                this.Status = "выполнен";
            }
            db.CloseConnection();
        }


        Word.Application wrdApp;
        Word._Document wrdDoc;
        Object oMissing = System.Reflection.Missing.Value;
        Object oFalse = false;

        private void InsertLines(int LineNum)
        {
            int iCount;

            // Insert "LineNum" blank lines. 
            for (iCount = 1; iCount <= LineNum; iCount++)
            {
                wrdApp.Selection.TypeParagraph();
            }
        }


        public void Report()
        {
            DBSQL dBSQL = new DBSQL();
            List<Task> tasks = dBSQL.AllTasks(this);
            List<Emploee> emploes = dBSQL.AllEmploees();

            Word.Selection wrdSelection;
            Word.MailMerge wrdMailMerge;
            Word.MailMergeFields wrdMergeFields;
            Word.Table wrdTable;
            string StrToAdd;

            wrdApp = new Word.Application();
            wrdApp.Visible = true;

            wrdDoc = wrdApp.Documents.Add(ref oMissing, ref oMissing,
                ref oMissing, ref oMissing);
            wrdDoc.Select();

            wrdSelection = wrdApp.Selection;
            wrdMailMerge = wrdDoc.MailMerge;

            StrToAdd = "Предприятие по производству электроники";
            wrdSelection.ParagraphFormat.Alignment =
                Word.WdParagraphAlignment.wdAlignParagraphCenter;
            wrdSelection.TypeText(StrToAdd);

            InsertLines(4);

            StrToAdd = "№ заказа: " + Id + "\nНазвание: " + Name + "\nДата:" + Date + "\n№ цеха: " + DepartmentNumber + "\nСтатус: " + Status + "\nСтоимость: " + Cost + "\nОписание: " + Description + "\nЭл.почта: " + Email + "\n\n";
            wrdSelection.ParagraphFormat.Alignment =
                Word.WdParagraphAlignment.wdAlignParagraphLeft;
            wrdSelection.TypeText(StrToAdd);
            wrdSelection.ParagraphFormat.Alignment =
                Word.WdParagraphAlignment.wdAlignParagraphRight;

            Object objDate = "dddd, MMMM dd, yyyy";
            wrdSelection.InsertDateTime(ref objDate, ref oFalse, ref oMissing,
                ref oMissing, ref oMissing);

            InsertLines(2);

            wrdTable = wrdDoc.Tables.Add(wrdSelection.Range, tasks.Count, 2,
                ref oMissing, ref oMissing);
            wrdTable.Columns[1].SetWidth(200, Word.WdRulerStyle.wdAdjustNone);
            wrdTable.Columns[2].SetWidth(200, Word.WdRulerStyle.wdAdjustNone);
            wrdTable.Rows[1].Cells.Shading.BackgroundPatternColorIndex =
                Word.WdColorIndex.wdGray25;
            wrdTable.Rows[1].Range.Bold = 1;
            wrdTable.Cell(1, 1).Range.Paragraphs.Alignment =
                Word.WdParagraphAlignment.wdAlignParagraphCenter;


            wrdDoc.Tables[1].Cell(1, 1).Range.InsertAfter("Задача");
            wrdDoc.Tables[1].Cell(1, 2).Range.InsertAfter("Исполнитель");

            for (int i = 0; i < tasks.Count; i++)
            {
                wrdDoc.Tables[1].Cell(i+2, 1).Range.InsertAfter(tasks[i].Description);
                for (int j = 0; j < emploes.Count; j++)
                {
                    if (tasks[i].IDuser == emploes[j].Id)
                        wrdDoc.Tables[1].Cell(i + 2, 2).Range.InsertAfter(emploes[j].FIO);

                }
            }

            Object oConst1 = Word.WdGoToItem.wdGoToLine;
            Object oConst2 = Word.WdGoToDirection.wdGoToLast;
            wrdApp.Selection.GoTo(ref oConst1, ref oConst2, ref oMissing, ref oMissing);
            InsertLines(2);

            wrdSelection = null;
            wrdMailMerge = null;
            wrdMergeFields = null;
            wrdDoc = null;
            wrdApp = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace CoreFramework
{
    public class ConnectionResults
    {
        public static ObservableCollection<ResultCompetition> GetResults()
        {
            return new ObservableCollection<ResultCompetition>(bdConnection.connection.ResultCompetition.ToList().Where(a=>a.Command.IsDeleted == false && a.Competition.IsDeleted == false));
        }

        public static void ExportExcel()
        {
            var allCommands = bdConnection.connection.Command.OrderBy(p => p.Name).ToList();

            Excel.Application application = new Excel.Application();
            application.SheetsInNewWorkbook = allCommands.Count();

            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);

            int startRowIndex = 1;

            for (int i = 0; i < allCommands.Count(); i++)
            {
                Excel.Worksheet worksheet = application.Worksheets.Item[i + 1];
                worksheet.Name = allCommands[i].Name;

                worksheet.Cells[1][startRowIndex] = "Название соревнования";
                worksheet.Cells[2][startRowIndex] = "Дата соревнования";
                worksheet.Cells[3][startRowIndex] = "Место в соревновании";
                startRowIndex++;
                var results = GetResults().Where(p => p.idCommand == allCommands[i].idCommand);
                foreach (var gr in results)
                {
                    worksheet.Cells[2][startRowIndex] = gr.Competition.Date;
                    worksheet.Cells[1][startRowIndex] = gr.Competition.Name;
                    worksheet.Cells[3][startRowIndex] = gr.Rank;
                    startRowIndex++;
                }
                worksheet.Columns.AutoFit();
                worksheet.Rows.AutoFit();
                startRowIndex = 1;
            }
            application.Visible = true;
        }

        public static List<ResultCompetition> GetResutCompet(int idCompet)
        {
            try
            {
                return GetResults().Where(tt => tt.idCompetition == idCompet).ToList();
            }

            catch // Exception исправить
            {
                return null;
            }
        }

        public static ResultCompetition GetResultsId(int idCommand, int idCompet)
        {
            ObservableCollection<ResultCompetition> results = GetResults();
            return results.Where(tt => tt.idCommand == idCommand && tt.idCompetition == idCompet).FirstOrDefault();
        }

        public static void RemoveResult(int idCommand, int idCompetition)
        {
            try
            {
                ResultCompetition com = bdConnection.connection.ResultCompetition.FirstOrDefault(p => p.idCommand == idCommand && p.idCompetition == idCompetition);
                bdConnection.connection.ResultCompetition.Remove(com);
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) // Exception исправить
            { 
                Console.WriteLine(ex.Message); 
            }
        }

        public static bool IsComCompetTrue(int Command,int Competition)
        {
            if (GetResults().Where(t => t.idCommand == Command && t.idCompetition == Competition).Count() == 0)
                return true;
            else
                return false;
        }

        public static bool IsRankTrue(int rank, int compet)
        {
            if (GetResults().Where(t => t.Rank == rank && t.idCompetition == compet).Count() == 0)
                return true;
            else
                return false;
        }

        public static void AddResult(ResultCompetition result)
        {
            try
            {
                result.Command = Connection.GetCommand(Convert.ToInt32(result.idCommand));
                result.Competition = Connection.GetCompetition(Convert.ToInt32(result.idCompetition));
                bdConnection.connection.ResultCompetition.Add(result);
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateResult(ResultCompetition result)
        {
            try
            {
                var res = bdConnection.connection.ResultCompetition.SingleOrDefault(tt => tt.Command.Name == result.Command.Name && tt.Competition.Name == result.Competition.Name);
                result.Command = Connection.GetCommand(Convert.ToInt32(result.idCommand));
                result.Competition = Connection.GetCompetition(Convert.ToInt32(result.idCompetition));
                res.Rank = result.Rank;
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) // Exception исправить
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

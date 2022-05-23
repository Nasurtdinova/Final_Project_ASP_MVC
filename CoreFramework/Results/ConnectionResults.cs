using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.IO;
using ExcelDataReader;
using Excel = Microsoft.Office.Interop.Excel;

namespace CoreFramework
{
    public class ConnectionResults
    {
        public static IExcelDataReader edr;

        public static ObservableCollection<ResultCompetition> GetResults()
        {
            return new ObservableCollection<ResultCompetition>(bdConnection.connection.ResultCompetition.ToList().Where(a=>a.Command.IsDeleted == false && a.Competition.IsDeleted == false));
        }

        public static void ExportExcel()
        {
            var allCommands = ConnectionCommands.GetCommands().OrderBy(p => p.Name).ToList();

            Excel.Application application = new Excel.Application();
            application.SheetsInNewWorkbook = allCommands.Count();

            Excel.Workbook workbook = application.Workbooks.Add(Type.Missing);

            int startRowIndex = 1;

            for (int i = 0; i < allCommands.Count(); i++)
            {
                Excel.Worksheet worksheet = application.Worksheets.Item[i + 1];
                worksheet.Name = allCommands[i].Name;
                worksheet.Cells[1][startRowIndex] = "Команда из города";
                worksheet.Cells[2][startRowIndex] = allCommands[i].City.Name;
                startRowIndex = 2;

                worksheet.Cells[1][startRowIndex] = "Название соревнования";
                worksheet.Cells[2][startRowIndex] = "Дата соревнования";
                worksheet.Cells[3][startRowIndex] = "Место в соревновании";
                startRowIndex++;
                var results = allCommands[i].ResultCompetition.OrderBy(p => p.Competition.Date).GroupBy(p => p.Competition.Date);
                foreach (var result in results)
                {
                    Excel.Range headerRange = worksheet.Range[worksheet.Cells[1][startRowIndex], worksheet.Cells[3][startRowIndex]];
                    headerRange.Merge();
                    headerRange.Value = result.Key.Value;
                    headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    headerRange.Font.Italic = true;
                    startRowIndex++;
                    foreach (var j in result)
                    {
                        worksheet.Cells[1][startRowIndex] = j.Competition.Name;
                        worksheet.Cells[2][startRowIndex] = j.Competition.NameVenue;
                        worksheet.Cells[3][startRowIndex] = j.Rank;
                    }
                    startRowIndex++;
                }
                worksheet.Columns.AutoFit();
                worksheet.Rows.AutoFit();
                startRowIndex = 1;
            }
            application.Visible = true;
        }

        public static void ReadFile(string fileNames)
        {
            var extension = fileNames.Substring(fileNames.LastIndexOf('.'));
            FileStream stream = File.Open(fileNames, FileMode.Open, FileAccess.Read);
            if (extension == ".xlsx")
                edr = ExcelReaderFactory.CreateOpenXmlReader(stream);
            else if (extension == ".xls")
                edr = ExcelReaderFactory.CreateBinaryReader(stream);
            var conf = new ExcelDataSetConfiguration
            {
                ConfigureDataTable = _ => new ExcelDataTableConfiguration { UseHeaderRow = true }
            };
            DataSet dataSet = edr.AsDataSet(conf);
            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    ResultCompetition res = new ResultCompetition()
                    {
                        Command = ConnectionCommands.GetCommandsId(Convert.ToInt32(dr[0])),
                        Competition = ConnectionCompetitions.GetCompetId(Convert.ToInt32(dr[1])),
                        Rank = Convert.ToInt32(dr[2])
                    };
                    AddResult(res);
                }
            }
            edr.Close();
        }

        public static List<ResultCompetition> GetResutCompet(int idCompet)
        {
            return GetResults().Where(tt => tt.idCompetition == idCompet).ToList();
        }

        public static ResultCompetition GetResultsId(int idCommand, int idCompet)
        {
            return GetResults().Where(tt => tt.idCommand == idCommand && tt.idCompetition == idCompet).FirstOrDefault();
        }

        public static void RemoveResult(int idCommand, int idCompetition)
        {
            try
            {
                ResultCompetition com = bdConnection.connection.ResultCompetition.FirstOrDefault(p => p.idCommand == idCommand && p.idCompetition == idCompetition);
                bdConnection.connection.ResultCompetition.Remove(com);
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) 
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
                result.Command = ConnectionCommands.GetCommandsId(Convert.ToInt32(result.idCommand));
                result.Competition = ConnectionCompetitions.GetCompetId(Convert.ToInt32(result.idCompetition));
                bdConnection.connection.ResultCompetition.Add(result);
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateResult(ResultCompetition result)
        {
            try
            {
                var res = bdConnection.connection.ResultCompetition.SingleOrDefault(tt => tt.Command.Name == result.Command.Name && tt.Competition.Name == result.Competition.Name);
                result.Command = ConnectionCommands.GetCommandsId(Convert.ToInt32(result.idCommand));
                result.Competition = ConnectionCompetitions.GetCompetId(Convert.ToInt32(result.idCompetition));
                res.Rank = result.Rank;
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

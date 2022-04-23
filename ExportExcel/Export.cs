using System;
using System.Collections.ObjectModel;
using System.Linq;
using CoreFramework;
using Excel = Microsoft.Office.Interop.Excel;

namespace ExportExcel
{
    public class Export
    {
        public static ObservableCollection<ResultCompetition> GetResults()
        {
            return new ObservableCollection<ResultCompetition>(bdConnection.connection.ResultCompetition.ToList().Where(a => a.Command.IsDeleted == false && a.Competition.IsDeleted == false));
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
    }
}

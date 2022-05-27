using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using ExcelDataReader;
using System.Data;

namespace CoreFramework
{
    public class ConnectionCompetitions
    {
        public static IExcelDataReader edr;

        public static Competition GetCompetId(int id)
        {
            return GetCompetitions().Where(tt => tt.idCompetition == id).FirstOrDefault();            
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
                    Competition com = new Competition()
                    {
                        Name = dr[0].ToString(),
                        Date = Convert.ToDateTime(dr[1]),
                        idCity = ConnectionUser.GetCity(dr[2].ToString()).idCity,
                        NameVenue = dr[3].ToString(),
                        Street = dr[4].ToString(),
                        Home = Convert.ToInt32(dr[5])
                    };
                    AddCompetition(com);
                }
            }
            edr.Close();
        }

        public static ObservableCollection<Competition> GetCompetitions()
        {
           return new ObservableCollection<Competition>(bdConnection.connection.Competition.ToList().Where(a => a.IsDeleted == false));
        }

        public static void AddCompetition(Competition compet)
        {
            try
            {
                compet.IsDeleted = false;

                bdConnection.connection.Competition.Add(compet);
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void RemoveCompetition(int id)
        {
            try
            {
                Competition compet = bdConnection.connection.Competition.FirstOrDefault(p => p.idCompetition == id);
                compet.IsDeleted = true;
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateCompet(Competition compet)
        {
            try
            {
                var competition = bdConnection.connection.Competition.SingleOrDefault(r => r.idCompetition == compet.idCompetition);
                competition.Name = compet.Name;
                competition.NameVenue = compet.NameVenue;
                competition.Date = compet.Date;
                competition.IsDeleted = false;
                competition.idCity = compet.idCity;
                competition.Home = compet.Home;
                competition.Street = compet.Street;
                bdConnection.connection.SaveChanges();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project_ASP_MVC.Core;

namespace WebAPI_Project.Service
{
    public static class CompetitionService
    {
        static List<Competition> Competitions { get; }

        static CompetitionService()
        {
            Competitions = Connection.GetCompetition();
        }

        public static List<Competition> GetAll() => Competitions;

        public static Competition Get(int id) => Competitions.FirstOrDefault(p => p.ID == id);

        public static void Add(Competition compet)
        {
            Competitions.Add(compet);
            Connection.AddCompetition(compet);
            //sportsman.ID = nextId++;
           
        }

        public static void Delete(int id)
        {
            var compet = Get(id);
            if (compet is null)
                return;
            Connection.RemoveCompetition(id);
            Competitions.Remove(compet);
        }

        public static void Update(Competition compet)
        {
            var index = Competitions.FindIndex(p => p.ID == compet.ID);
            if (index == -1)
                return;

            Connection.UpdateCompet(compet);
            Competitions[index] = compet;
        }
    }
}

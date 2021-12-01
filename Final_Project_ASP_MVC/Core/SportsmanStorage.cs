using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Project_ASP_MVC.Core
{
    public class SportsmanStorage : IEnumerable
    {
        public static List<Sportsman> projects { get; private set; } = Connection.GetProjects();

        public IEnumerator GetEnumerator()
        {
            return projects.GetEnumerator();
        }

        public void Add(Sportsman project)
        {
            Connection.AddProject(project);
            projects.Add(project);
        }

        public void RemoveByName(string name)
        {
            Connection.RemoveProject(name);
            projects.RemoveAll(p => p.Name == name);
        }
    }
}

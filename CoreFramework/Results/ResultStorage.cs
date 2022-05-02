using System.Collections.ObjectModel;

namespace CoreFramework
{
    public class ResultStorage
    {
        public static ObservableCollection<ResultCompetition> results { get; private set; } = ConnectionResults.GetResults();

        public static void Add(ResultCompetition result)
        {
            ConnectionResults.AddResult(result);
            results.Add(result);
        }

        public static void RemoveByName(int idCommand, int idCompetition)
        {
            ConnectionResults.RemoveResult(idCommand, idCompetition);
            results = ConnectionResults.GetResults();
        }

        public static void Update(ResultCompetition result)
        {
            ConnectionResults.UpdateResult(result);
            results = ConnectionResults.GetResults();
        }
    }
}

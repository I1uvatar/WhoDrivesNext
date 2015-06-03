using System.Collections.Generic;
using System.Linq;
using WhoDrivesNextConsoleClient.Model;

namespace WhoDrivesNextConsoleClient.Helper
{
    class CombinationsHelper
    {
        private static IEnumerable<int> ConstructSetFromBits(int i)
        {
            for (int n = 0; i != 0; i /= 2, n++)
            {
                if ((i & 1) != 0)
                    yield return n;
            }
        }

        private static IEnumerable<List<Person>> ProduceEnumeration(List<Person> persons)
        {
            for (int i = 0; i < (1 << persons.Count); i++)
            {
                yield return
                    ConstructSetFromBits(i).Select(n => persons[n]).ToList();
            }
        }

        public static List<List<Person>> ProduceList(List<Person> persons )
        {
            return ProduceEnumeration(persons).ToList();
        }
    }
}
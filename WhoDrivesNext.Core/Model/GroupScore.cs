using System.Collections.Generic;
using System.Linq;

namespace WhoDrivesNext.Core.Model
{
    public class GroupScore
    {
        public Dictionary<Person,int> PersonPoints { get; set; }
        public Group ScoreForGroup { get; set; }

        public GroupScore(Group group)
        {
            ScoreForGroup = group;
            InitializeScoreFromGroup();
        }
        
        public void ResetAllPersonPoints()
        {
           PersonPoints.Clear();
           InitializeScoreFromGroup();
        }

        public void InitializeScoreFromGroup()
        {
            PersonPoints = new Dictionary<Person, int>();
            foreach (var person in ScoreForGroup.Persons)
            {
                PersonPoints.Add(person,0);
            }
        }

        public bool AddScore(Person person,int score)
        {
            var key = PersonPoints.Keys.ToList().Find(p => p.PersonId == person.PersonId);
            if (key != null)
            {
                PersonPoints[key] += score;
                return true;
            }

            return false;          
        }

        //Set the score for other memmers
        public void AddScoreToGroupMembers(Person excludePerson)
        {
            var listOfKeysForGrupMembersToModify = PersonPoints.Keys.Where(key => key.PersonId != excludePerson.PersonId).ToList();
            foreach (var person in listOfKeysForGrupMembersToModify)
            {
                AddScore(person, 1);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using WhoDrivesNext.Core.Helper;
using WhoDrivesNext.Core.Model;

namespace WhoDrivesNext.Core
{
    public class ApplicationCore
    {
        private  List<Person> _persons;
        private  List<Group> _groups;
        private  List<GroupScore> _groupScores;

        public ApplicationCore()
        {
            InitializeCollections();
        }

        private void InitializeCollections()
        {
            _persons = new List<Person>();
            _groups = new List<Group>();
            _groupScores = new List<GroupScore>();
        }

        public List<Person> Persons
        {
            get { return _persons; }
            set { _persons = value; }
        }

        public List<Group> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }

        public List<GroupScore> GroupScores
        {
            get { return _groupScores; }
            set { _groupScores = value; }
        }

        public void AddPerson(Person person)
        {
            _persons.Add(person);
        }

        public void InitialGroupAndScoresGeneration()
        {
            //generating all posible group combinations but take only those who has 2 or more members
            var generatedGroups = CombinationsHelper.ProduceList(_persons).Where(i => i.Count >= 2).ToList();
            _groups = new List<Group>();
            foreach (var generatedGroup in generatedGroups)
            {
                var group = new Group() { GroupId = Guid.NewGuid() };
                group.Name = CommonHelper.ExtractGroupNameFromGroup(generatedGroup);
                group.Persons = generatedGroup;

                _groups.Add(group);
            }

            _groupScores = _groups.Select(group => new GroupScore(group)).ToList();
        }

        public GroupScore GetScroreByGroupName(string groupName)
        {
            var score = _groupScores.Find(gs => gs.ScoreForGroup.Name.ToLower() == groupName.ToLower());
            return score;
        }

        public Person GetPersonWhoDrivesNextByScore(GroupScore score)
        {
            if (score == null)
            {
                return null;
            }
            var personId = score.PersonPoints.OrderByDescending(kp => kp.Value).FirstOrDefault().Key.PersonId;
            var personWhoDrivesNext = CommonHelper.FindPersonById(personId, _persons);
            return personWhoDrivesNext;
        }

        public Person GetPersonWhoDrivesNextByGroupName(string groupName)
        {
            return GetPersonWhoDrivesNextByScore(GetScroreByGroupName(groupName));
        }

        public bool AddTripToScore(GroupScore score, Person driver)
        {
            if (score == null || driver == null)
            {
                return false;
            }
            
            var foundPerson = CommonHelper.FindPersonByName(driver.FirstName, driver.LastName, _persons);
            if (foundPerson == null)
            {
                return false;
            }

            score.AddScoreToGroupMembers(driver);
            return true;
        }

        public void RegenerateGroupsAndScores()
        {
            //generating all posible group combinations but take only those who has 2 or more members
            var generatedGroups = CombinationsHelper.ProduceList(_persons).Where(i => i.Count >= 2).ToList();


            var grp = new List<Group>();
            foreach (var generatedGroup in generatedGroups)
            {
                var group = new Group() { GroupId = Guid.NewGuid() };
                group.Name = CommonHelper.ExtractGroupNameFromGroup(generatedGroup);
                group.Persons = generatedGroup;

                grp.Add(group);
            }

            var newGroups = grp.FindAll(g => _groups.Find(e => e.Name == g.Name) == null).ToList();
            var newGroupScores = newGroups.Select(group => new GroupScore(group)).ToList();

            _groups.AddRange(newGroups);
            _groupScores.AddRange(newGroupScores);
        }

        public void AddPersonAndRegenerateGroupsAndScores(Person person)
        {
            AddPerson(person);
            RegenerateGroupsAndScores();
        }
    
    }
}
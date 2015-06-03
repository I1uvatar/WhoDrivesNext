using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhoDrivesNext.Core;
using WhoDrivesNext.Core.Model;
using WhoDrivesNext.Core.Helper;


namespace WhoDrivesNextConsoleClient
{
    class Program
    {
        private static ApplicationCore _appCore;

        static void Main(string[] args)
        {
            _appCore = new ApplicationCore();
            FirstTimeStarted();
            var prompt = -1;
            while (prompt != 0)
            {
                prompt = DisplayMainMenu();
                ProccessCommand(prompt);
            }
            
            Console.WriteLine("Press <enter> to quit.");
            Console.ReadLine();
            Console.Clear();            
        }

        #region Basic operations using Console

        private static void InitialSetup()
        {
            Console.Write("Numer of persons: ");
            var userInput = Console.ReadLine();

            int personNum = 0;
            int.TryParse(userInput, out personNum);
            if (personNum == 0)
            {
                Console.WriteLine("Error parsing the entered input or you entered 0 persons. \n ");
                return;
            }

           

            for (int i = 0; i < personNum; i++)
            {
                Console.Clear();
                Console.WriteLine("Enter the information for {0}. person....", i + 1);
                var person = new Person() {PersonId = Guid.NewGuid()};
                Console.Write("First name: ");
                userInput = Console.ReadLine();
                person.FirstName = userInput;

                Console.Write("Last name: ");
                userInput = Console.ReadLine();
                person.LastName = userInput;
                _appCore.AddPerson(person);
            }
            
            _appCore.InitialGroupAndScoresGeneration();
        }

        private static void FirstTimeStarted()
        {
            Console.WriteLine("You have started the aplication for the first time. Initial setup is mandatoty. Press <enter> to continue.");
            Console.ReadLine();
            ProccessCommand(1);
        }

        private static void DisplayWhoDrivesNext()
        {
            Console.Clear();
            Console.WriteLine("Who drives next in group");
            var userInput = string.Empty;

            var score = DisplayGroupsAndReturnScoreByGroupName();
            if (score == null)
            {
                Console.Write("Can't find group with name {0}.\nPress <enter> to skip to main menu", userInput);
                userInput = Console.ReadLine();
                return;
            }

            var personWhoDrivesNext = _appCore.GetPersonWhoDrivesNextByScore(score);
            Console.WriteLine("Next person who drives is: {0}",
                personWhoDrivesNext.FirstName + " " + personWhoDrivesNext.LastName);

            Console.WriteLine("Press <enter> to return to main menu.");
            Console.ReadLine();
        }

        private static void FindGroupAddTrip()
        {
            Console.Clear();
            Console.WriteLine("ENTER TRIP INTO GROUP");
            var userInput = string.Empty;
            var score = DisplayGroupsAndReturnScoreByGroupName();

            if (score == null)
            {
                Console.Write("Can't find group with such name.\nPress <enter> to skip to main menu");
                userInput = Console.ReadLine();
                return;
            }

            var p = new Person();

            Console.WriteLine("Who is the driver? ");
            Console.Write("First name: ");
            p.FirstName = Console.ReadLine();
            Console.Write("Last name: ");
            p.LastName = Console.ReadLine();
            var foundPerson = CommonHelper.FindPersonByName(p.FirstName, p.LastName, _appCore.Persons);
            if (foundPerson == null)
            {
                Console.WriteLine("Can't find person with name {0}.\nPress <enter> to skip to main menu", p.FirstName + " " + p.LastName);
                userInput = Console.ReadLine();
                return;
            }
            p.PersonId = foundPerson.PersonId;

            if (_appCore.AddTripToScore(score, p))
            {
                Console.WriteLine("Trip sucessfuly added. Press <enter> to return to main menu.");
                Console.ReadLine();                        
            }
            else
            {
                Console.WriteLine("Trip was not sucessfuly added. Press <enter> to return to main menu.");
                Console.ReadLine();                        
            }            
        }

        private static void AddNewPersonAndRegenerateGroups()
        {
            Console.Clear();
            var userInput = string.Empty;

            Console.WriteLine("Enter the information for person....");
            var person = new Person() { PersonId = Guid.NewGuid() };
            Console.Write("First name: ");
            userInput = Console.ReadLine();
            person.FirstName = userInput;

            Console.Write("Last name: ");
            userInput = Console.ReadLine();
            person.LastName = userInput;
            _appCore.AddPersonAndRegenerateGroupsAndScores(person);
            
            Console.WriteLine("New person sucessfuly added. New groups and scores added. Press <enter> to return to main menu.");
            Console.ReadLine();
        }

        private static void WriteOutPersonsToCosole(List<Person> persons)
        {
            if(persons != null) Console.WriteLine(CommonHelper.WriteOutPersons(persons));
        }

        private static string WriteOutGroups(List<Group> groups)
        {
            var groupFromatString = "Group name: {0} \nPersons in group:\n{1}";
            var sb = new StringBuilder();
            foreach (var group in groups)
            {
                sb.AppendLine(string.Format(groupFromatString, group.Name, CommonHelper.WriteOutPersons(group.Persons)));
            }

            return sb.ToString();
        }

        private static GroupScore DisplayGroupsAndReturnScoreByGroupName()
        {
            Console.WriteLine("Available groups:");
            WriteOutGroupsToConsole(_appCore.Groups);

            Console.Write("Enter group name: ");
            var userInput = Console.ReadLine();

            var score = _appCore.GetScroreByGroupName(userInput);
            return score;
        }


        private static void WriteOutGroupsToConsole(List<Group> groups)
        {
            if(groups != null) Console.WriteLine(WriteOutGroups(groups));
        }

        #endregion

        #region Menu plumbing

        private static void ProccessCommand(int prompt)
        {
            switch (prompt)
            {
                case 1:
                    Console.Clear();
                    InitialSetup();
                    Console.WriteLine("Initial setup successfuly completed. Press <enter> to return to main menu.");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("List of persons....");
                    WriteOutPersonsToCosole(_appCore.Persons);
                    Console.Write("Press <enter> to return to main menu.");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("List of groups....");
                    WriteOutGroupsToConsole(_appCore.Groups);
                    Console.Write("Press <enter> to return to main menu.");
                    Console.ReadLine();
                    break;
                case 4:
                    FindGroupAddTrip();
                    break;
                case 5:
                    DisplayWhoDrivesNext();
                    break;
                case 6:
                    AddNewPersonAndRegenerateGroups();
                    break;
            }
        }

        private static int DisplayMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Initial setup--------------------------------<1>");
            Console.WriteLine("Display persons------------------------------<2>");
            Console.WriteLine("Display groups-------------------------------<3>");
            Console.WriteLine("Enter trip into group------------------------<4>");
            Console.WriteLine("Who drivers next in group--------------------<5>");
            Console.WriteLine("Add new person-------------------------------<6>");
            Console.WriteLine("Quit-----------------------------------------<0>");
            Console.Write("\nEnter: ");
            var userChoice = Console.ReadLine();
            int selectedCommand = 0;
            int.TryParse(userChoice, out selectedCommand);

            return selectedCommand;
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using WhoDrivesNext.Core.Model;

namespace WhoDrivesNext.Core.Helper
{
    public class CommonHelper
    {
        public static string WriteOutPersons(List<Person> persons)
        {
            var personFormatString = "Name: {0}";
            var sb = new StringBuilder();
            foreach (var person in persons)
            {
                sb.AppendLine(String.Format(personFormatString, person.FirstName + " " + person.LastName));                
            }

            return sb.ToString();
        }

        public static string ExtractGroupNameFromGroup(List<Person> generatedGroup)
        {
            var sb = new StringBuilder();
            foreach (var person in generatedGroup)
            {
                sb.Append(person.FirstName);
            }

            return sb.ToString();
        }

        public static Person FindPersonByName(string firstName, string lastName, List<Person> persons)
        {
            return persons.Find(p => p.FirstName == firstName && p.LastName == lastName);
        }

        public static Person FindPersonById(Guid id, List<Person> persons)
        {
            return persons.Find(p => p.PersonId == id);
        }        
    }
}
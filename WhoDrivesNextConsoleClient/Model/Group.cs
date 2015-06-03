using System;
using System.Collections.Generic;

namespace WhoDrivesNextConsoleClient.Model
{
    public class Group
    {
        public Guid GroupId { get; set; }
        public String Name { get; set; }
        public List<Person> Persons { get; set; }   
    }
}
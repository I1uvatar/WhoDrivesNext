using System;
using System.Collections.Generic;

namespace WhoDrivesNext.Core.Model
{
    public class Group : IPersistentEntity
    {
        public Guid GroupId { get; set; }
        public String Name { get; set; }
        public List<Person> Persons { get; set; }
        public int ID { get; set; }
    }
}
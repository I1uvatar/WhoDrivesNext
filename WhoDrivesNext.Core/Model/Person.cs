using System;

namespace WhoDrivesNext.Core.Model
{
    public class Person : IPersistentEntity
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }
    }
}

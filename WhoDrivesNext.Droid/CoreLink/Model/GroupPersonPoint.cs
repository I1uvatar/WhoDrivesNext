using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace WhoDrivesNext.Core.Model
{
    public class GroupPersonPoint : IPersistentEntity
    {
        public Guid PersonId { get; set; }
        public string GroupName { get; set; }
        public int Score { get; set; }
        public int ID { get; set; }
    }
}

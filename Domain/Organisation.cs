using System;
using System.Collections.Generic;

namespace Domain
{
    public class Organisation : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Address PrimaryAddress { get; set; }
        public IEnumerable<Address> Addresses { get; set; }  
        public IEnumerable<User> Users { get; set; }
    }
}

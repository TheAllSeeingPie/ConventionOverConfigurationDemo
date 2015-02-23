using System;
using System.Collections.Generic;

namespace Domain
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Permission> Permissions { get; set; }
        //Probably "password1" lolololololol
        public string SuperSecretUnencryptedPassword { get; set; }
        public int BankAccount { get; set; }
        public int SortCode { get; set; }
    }
}
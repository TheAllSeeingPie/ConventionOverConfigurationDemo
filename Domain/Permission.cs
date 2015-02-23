using System;

namespace Domain
{
    public class Permission : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
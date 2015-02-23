using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Domain;

namespace ValueResolvers
{
    public class UsersResolver : ValueResolver<IEnumerable<User>, string>
    {
        protected override string ResolveCore(IEnumerable<User> source)
        {
            return string.Join(", ", source.Select(u => u.Name));
        }
    }
}

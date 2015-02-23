using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Domain;

namespace ValueResolvers
{
    public class UserCountResolver : ValueResolver<IEnumerable<User>, int>
    {
        protected override int ResolveCore(IEnumerable<User> source)
        {
            return source.Count();
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Domain;

namespace ValueResolvers
{
    public class PermissionsResolver : ValueResolver<IEnumerable<Permission>, string>
    {
        protected override string ResolveCore(IEnumerable<Permission> source)
        {
            return string.Join(", ", source.Select(p => p.Name).OrderBy(p => p));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Domain;

namespace ValueResolvers
{
    public class AddressesResolver : ValueResolver<IEnumerable<Address>, string>
    {
        protected override string ResolveCore(IEnumerable<Address> source)
        {
            return string.Join(Environment.NewLine, source.Select(s => string.Join(", ", s.Address1, s.Postcode)));
        }
    }
}
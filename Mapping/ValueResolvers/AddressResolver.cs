using System.Linq;
using AutoMapper;
using Domain;

namespace ValueResolvers
{
    public class AddressResolver : ValueResolver<Address, string>
    {
        protected override string ResolveCore(Address source)
        {
            var address = new[] {source.Address1, source.Address2, source.Address3, source.Address4, source.Postcode};
            return string.Join(", ", address.Where(a => !string.IsNullOrWhiteSpace(a)));
        }
    }
}
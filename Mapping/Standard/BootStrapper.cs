using DataTransferObjects;
using Domain;
using ValueResolvers;
using AutoMapper;

namespace Mapping.Standard
{
    public static class BootStrapper
    {
        public static void Init()
        {
            Mapper.CreateMap<User, UserDto>()
                .ForMember(user => user.Address,
                    member => member.ResolveUsing<AddressResolver>().FromMember(user => user.Address))
                .ForMember(user => user.Permissions,
                    member => member.ResolveUsing<PermissionsResolver>().FromMember(user => user.Permissions));

            Mapper.CreateMap<User, UserLimitedDto>()
                .ForMember(user => user.Address,
                    member => member.ResolveUsing<AddressResolver>().FromMember(user => user.Address));

            Mapper.CreateMap<Organisation, OrganisationDto>()
                .ForMember(org => org.PrimaryAddress,
                    member => member.ResolveUsing<AddressResolver>().FromMember(org => org.PrimaryAddress))
                .ForMember(org => org.Addresses,
                    member => member.ResolveUsing<AddressesResolver>().FromMember(org => org.Addresses))
                .ForMember(org => org.UsersCount,
                    member => member.ResolveUsing<UserCountResolver>().FromMember(org => org.Users))
                .ForMember(org => org.Users,
                    member => member.ResolveUsing<UsersResolver>().FromMember(org => org.Users));
        }
    }
}
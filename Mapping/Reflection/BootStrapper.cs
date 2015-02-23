using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Domain;

namespace Mapping.Reflection
{
    public static class BootStrapper
    {
        public static void Init()
        {
            //Attempt scanning the entire AppDomain - Not recommended but sometimes a necessary evil
            //Doing this in a static class and only once isn't going to be the worst thing you could do in C#
            var valueresolvers = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
                .Where(t => t.BaseType != null && t.BaseType.GetInterfaces().Any(i => i == typeof (IValueResolver)))
                .Where(t => t.BaseType.GenericTypeArguments.Any() && t.BaseType.GenericTypeArguments.Count() ==  2)
                .ToArray();

            //This is a nicer way of finding a more specific thing you need. It's also compile time friendly
            var entities =
                Assembly.GetAssembly(typeof (IEntity))
                    .GetTypes()
                    .Where(t => t.GetInterfaces().Any(i => i == typeof (IEntity)))
                    .ToArray();

            //Just showing it's possible to load assemblies given a known name
            //Renaming your assembly, changing the private key or adjusting the version will causes issues
            var dtos =
                Assembly.Load("DataTransferObjects")
                .GetTypes()
                .ToArray();

            foreach (var e in entities)
            {
                var entity = e;
                var entityProperties = entity.GetProperties();
                
                foreach (var dto in dtos.Where(dto => dto.Name.StartsWith(e.Name)))
                {
                    var map = Mapper.CreateMap(entity, dto);

                    foreach (var dtoProp in dto.GetProperties())
                    {
                        var entityProp = entityProperties.SingleOrDefault(p => dtoProp.Name.StartsWith(p.Name));

                        if (entityProp == null)
                        {
                            continue;
                        }

                        var valueresolver = valueresolvers.FirstOrDefault(vr =>
                                vr.BaseType.GenericTypeArguments.First() == entityProp.PropertyType &&
                                vr.BaseType.GenericTypeArguments.Last() == dtoProp.PropertyType);
                        
                        if (valueresolver != null)
                        {
                            map.ForMember(dtoProp.Name,
                                member => member.ResolveUsing(valueresolver).FromMember(entityProp.Name));
                        }
                    }
                }
            }
        }
    }
}

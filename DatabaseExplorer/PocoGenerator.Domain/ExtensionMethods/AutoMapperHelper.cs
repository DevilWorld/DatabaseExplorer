using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace PocoGenerator.Domain.ExtensionMethods
{
    public static partial class ExtensionMethods
    {
        public static IMappingExpression<TSource, TDestination> MapTo<TSource, TDestination>()
        {
            return Mapper.CreateMap<TSource, TDestination>();
        }

        public static TDestination MapToModel<TDestination>(this object source)
        {
            return Mapper.Map<TDestination>(source);
        }
    }
}

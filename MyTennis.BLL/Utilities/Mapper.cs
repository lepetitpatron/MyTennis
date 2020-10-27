using AutoMapper;
using System.Collections.Generic;

namespace MyTennis.BLL.Utilities
{
    internal class Mapper
    {
        internal static TDestination Map<TSource, TDestination>(TSource objectToMap)
        {
            MapperConfiguration config = new MapperConfiguration(cfg => cfg.CreateMap<TSource, TDestination>());
            IMapper mapper = config.CreateMapper();

            return mapper.Map<TDestination>(objectToMap);
        }

        internal static List<TDestination> MapList<TSource, TDestination>(List<TSource> listToMap)
        {
            List<TDestination> items = new List<TDestination>();
            foreach (var item in listToMap)
            {
                items.Add(Map<TSource, TDestination>(item));
            }

            return items;
        }
    }
}

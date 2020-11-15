using AutoMapper;
using MyTennis.Core.DTO;
using MyTennis.DAL.Entities;

namespace MyTennis.BLL.Utilities
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Member, MemberDTO>().ReverseMap();
            CreateMap<Gender, GenderDTO>().ReverseMap();
            CreateMap<Fine, FineDTO>().ReverseMap();
        }
    }
}

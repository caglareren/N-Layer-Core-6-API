using AutoMapper;
using NLayerCore6.Core;
using NLayerCore6.Core.DTOs;

namespace NLayerCore6.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AddressInfo, AddressInfoDto>().ReverseMap();
            CreateMap<AddressInfoDto, AddressInfo>();
        }
    }
}

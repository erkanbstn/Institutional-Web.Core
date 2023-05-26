using AutoMapper;
using Institutional.Core.Core.Models;
using Institutional.Core.Dto.Dtos.Carousel;
using Institutional.Core.Dto.Dtos.CarouselThumbnail;

namespace InstitutionalUI.Core.Mapping.AutoMapperProfile
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<CarouselAddDto, Carousel>().ReverseMap();
            CreateMap<CarouselListDto, Carousel>().ReverseMap();
            CreateMap<CarouselEditDto, Carousel>().ReverseMap();

            CreateMap<CarouselThumbnailListDto, CarouselThumbnail>().ReverseMap();
            CreateMap<CarouselThumbnailEditDto, CarouselThumbnail>().ReverseMap();
        }
    }
}

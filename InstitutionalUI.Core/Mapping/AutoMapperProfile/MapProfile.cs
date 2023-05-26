using AutoMapper;
using Institutional.Core.Core.Models;
using Institutional.Core.Dto.Dtos.About;
using Institutional.Core.Dto.Dtos.Carousel;
using Institutional.Core.Dto.Dtos.CarouselThumbnail;
using Institutional.Core.Dto.Dtos.Contact;
using Institutional.Core.Dto.Dtos.Event;
using Institutional.Core.Dto.Dtos.PageImage;
using Institutional.Core.Dto.Dtos.Testimonial;

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

            CreateMap<TestimonialAddDto, Testimonial>().ReverseMap();
            CreateMap<TestimonialEditDto, Testimonial>().ReverseMap();
            CreateMap<TestimonialListDto, Testimonial>().ReverseMap();

            CreateMap<PageImageListDto,PageImage>().ReverseMap();
            CreateMap<PageImageEditDto,PageImage>().ReverseMap();

            CreateMap<EventListDto, Event>().ReverseMap();
            CreateMap<EventEditDto, Event>().ReverseMap();

            CreateMap<ContactListDto, Contact>().ReverseMap();
            CreateMap<ContactEditDto, Contact>().ReverseMap();

            CreateMap<AboutEditDto, About>().ReverseMap();
            CreateMap<AboutListDto, About>().ReverseMap();
        }
    }
}

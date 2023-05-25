using Institutional.Core.Repository.Abstract;
using Institutional.Core.Repository.Concrete;
using Institutional.Core.Service.Abstract;
using Institutional.Core.Service.Concrete;

namespace InstitutionalUI.Core.Extensions
{
    public static class ProgramExtension
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICarouselService, CarouselManager>();
            services.AddScoped<ICarouselRepository, EFCarouselRepository>();

            services.AddScoped<ICarouselThumbnailService, CarouselThumbnailManager>();
            services.AddScoped<ICarouselThumbnailRepository, EFCarouselThumbnailRepository>();

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutRepository, EFAboutRepository>();

            services.AddScoped<IEventService, EventManager>();
            services.AddScoped<IEventRepository, EFEventRepository>();

            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductRepository, EFProductRepository>();

            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<ITestimonialRepository, EFTestimonialRepository>();

            services.AddScoped<IPageImageService, PageImageManager>();
            services.AddScoped<IPageImageRepository, EFPageImageRepository>();

            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IContactRepository, EFContactRepository>();
        }
    }
}

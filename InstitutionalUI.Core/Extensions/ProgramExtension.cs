using Institutional.Core.Repository.Abstract;
using Institutional.Core.Repository.Concrete;
using Institutional.Core.Service.Abstract;
using Institutional.Core.Service.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.FileProviders;

namespace InstitutionalUI.Core.Extensions
{
    public static class ProgramExtension
    {
        public static void ContainerDependencies(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(x => { x.LoginPath = "/Auth/SignIn"; });

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

            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageRepository, EFMessageRepository>();

            services.AddScoped<IManagerService, ManagerManager>();
            services.AddScoped<IManagerRepository, EFManagerRepository>();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));

        }
    }
}

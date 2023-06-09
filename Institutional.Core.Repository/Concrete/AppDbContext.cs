﻿using Institutional.Core.Core.Models;
using Microsoft.EntityFrameworkCore;
namespace Institutional.Core.Repository.Concrete
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<CarouselThumbnail> CarouselThumbnails { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<PageImage> PageImages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Manager> Managers{ get; set; }
    }
}

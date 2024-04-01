using Microsoft.EntityFrameworkCore;

namespace NewWebApp.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<News> News { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<News>().HasData(new News
            {
                Id = new Guid("716C2E99-6F6C-4472-81A5-43C56E11637C"),
                Title = "Тестовая новость",
                Text = "Добавьте какую-нибудь новость в панели администратора!",
                TitleImagePath = "emblem.jpg",
                Data = DateTime.Now
            });
        }
    }
}

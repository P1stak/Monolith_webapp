using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NewWebApp.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        { 
            Database.EnsureCreated();
        }
        public DbSet<News> News { get; set; } = null!;//данное свойство в принципе не будет иметь значение null
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<News>().HasData(new News
            {
                Id = new Guid("716C2E99-6F6C-4472-81A5-43C56E11637C"),
                Title = "Тестовая новость",
                Text = "Добавьте какую-нибудь новость в панели администратора!",
                TitleImagePath = "/images/1.jpg",
                Data = DateTime.Now

            });
			modelBuilder.Entity<News>().HasData(new News
			{
				Id = new Guid("116C2E99-6F6C-4472-81A5-43C56E11637C"),
				Title = "У нас работают толкьо лучшие",
				Text = "Добавьте какую-нибудь новость в панели администратора!",
				TitleImagePath = "/images/2.jpg",
				Data = DateTime.Now

			});
			modelBuilder.Entity<News>().HasData(new News
			{
				Id = new Guid("216C2E99-6F6C-4472-81A5-43C56E11637C"),
				Title = "А у нас худшие",
				Text = "Добавьте какую-нибудь новость в панели администратора!",
				TitleImagePath = "/images/3.jpg",
				Data = DateTime.Now

			});
		}
    }
}

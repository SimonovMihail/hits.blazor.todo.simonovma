using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TodoServerApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Interest> Interests { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Message>()
            .HasOne(m => m.Sender)
            .WithMany()
            .HasForeignKey(m => m.SenderId)
            .OnDelete(DeleteBehavior.Restrict); // запрещаем каскадное удаление (чтобы sql не вонял)

            builder.Entity<Message>()
                .HasOne(m => m.Receiver)
                .WithMany()
                .HasForeignKey(m => m.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict); // запрещаем каскадное удаление (чтобы sql не вонял)

            builder.Entity<Interest>().HasData(
                new Interest { Id = 1, Title = "Спорт" },
                new Interest { Id = 2, Title = "Музыка" },
                new Interest { Id = 3, Title = "Путешествия" },
                new Interest { Id = 4, Title = "Игры" },
                new Interest { Id = 5, Title = "Программирование" }
            );

            builder.Entity<Profile>().HasData(
                new() { Id = 1, Name = "Катя", Age = 19, City = "Когалым", Bio = "Ищу крутого", LastActive = DateTime.Now.AddMonths(-2) },
                new() { Id = 2, Name = "Димитрий", Age = 21, City = "Артёмовск", Bio = "Ищу игрока в покер", LastActive = DateTime.Now.AddDays(-7) },
                new() { Id = 3, Name = "Егор", Age = 23, City = "Тюмень", Bio = "Хожу в качалку", LastActive = DateTime.Now.AddHours(-21) }
            );
        }
    }
}

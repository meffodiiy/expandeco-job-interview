using Bogus;
using Microsoft.EntityFrameworkCore;

namespace Expandeco.JobInterview.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var faker = new Faker("sk");

            modelBuilder.Entity<Language>().HasData(new Language { Id = 1, Title = "Angličtina" });
            modelBuilder.Entity<Language>().HasData(new Language { Id = 2, Title = "Slovenčina" });
            modelBuilder.Entity<Language>().HasData(new Language { Id = 3, Title = "Čeština" });
            modelBuilder.Entity<Language>().HasData(new Language { Id = 4, Title = "Nemčina" });

            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 1, Title = "Manažér" });
            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 2, Title = "Prekladateľ" });
            modelBuilder.Entity<UserType>().HasData(new UserType { Id = 3, Title = "Klient" });

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Name = faker.Name.FullName(), TypeId = 1 });

            for (int i = 2; i <= 7; i++)
                modelBuilder.Entity<User>().HasData(new User { Id = i, Name = faker.Name.FullName(), TypeId = 2 });
            for (int i = 8; i <= 10; i++)
                modelBuilder.Entity<User>().HasData(new User { Id = i, Name = faker.Name.FullName(), TypeId = 3 });


            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<Translation>().HasData(new Translation
                {
                    Id = i,
                    Title = string.Join(" ", faker.Lorem.Words()),
                    Text = faker.Lorem.Text(),
                    CreatedById = faker.Random.Int(8, 10),
                    AssignedToId = faker.Random.Bool() ? faker.Random.Int(2, 7) : default(int?),
                    SourceLanguageId = faker.Random.Int(1, 2),
                    TargetLanguageId = faker.Random.Int(3, 4)
                });
            }
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Translation> Translations { get; set; }
    }
}

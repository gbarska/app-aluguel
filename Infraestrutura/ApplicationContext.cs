using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Dominio.Usuarios;
using Dominio.Reservas;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infraestrutura.Data
{
    public sealed class ApplicationContext : DbContext
    {
        private static readonly Type[] EnumerationTypes = { typeof(Uf) };

        public DbSet<Local> Locais { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Uf> Estados { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ILoggerFactory loggerFactory = LoggerFactory.Create(
            builder =>
            {
              builder
               .AddFilter((category, level) =>
                  category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information);
            });

            optionsBuilder
                .UseLazyLoadingProxies()
                //if debugging
                .UseLoggerFactory(loggerFactory)
                .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
     public override int SaveChanges()
        {
            IEnumerable<EntityEntry> enumerationEntries = ChangeTracker.Entries()
                .Where(x => EnumerationTypes.Contains(x.Entity.GetType()));

            foreach (EntityEntry enumerationEntry in enumerationEntries)
            {
                enumerationEntry.State = EntityState.Unchanged;
            }
            return base.SaveChanges();
        }
    }
}


//exemplos mappings
            //HasConversion for valueObjects that have only one property -> Value
            // modelBuilder.Entity<Customer>(x => {
            //     x.ToTable("Customers").HasKey(k => k.Id);
            //     x.Property(p => p.Id).HasColumnName("CustomerID");
            //     x.Property(p => p.Email)
            //         .HasConversion(p => p.Value, p => Email.Create(p).Value);
            //     x.Property(p => p.Name)
            //         .HasConversion(p => p.Value, p => CustomerName.Create(p).Value);
            //     x.Property(p => p.MoneySpent)
            //         .HasConversion(p => p.Value, p => Dollars.Create(p).Value);
                
            //     x.HasOne(p => p.FavoriteMovieCategory).WithMany();

            //     x.HasMany(p => p.PurchasedMovies).WithOne(p => p.Customer)
            //         .OnDelete(DeleteBehavior.Cascade)
            //         .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);

            //     x.OwnsOne( p => p.Status, p => {
            //         p.Property(pp => pp.Type).HasColumnName("Status");
            //         p.Property(pp => pp.ExpirationDate).HasColumnName("StatusExpirationDate")
            //             .HasConversion(p => p.Date, p => ExpirationDate.Create(p).Value);
            //     });
            // });

            // modelBuilder.Entity<MovieCategory>(x =>
            // {
            //     x.ToTable("MovieCategories").HasKey(k => k.Id);
            //     x.Property(p => p.Id).HasColumnName("MovieCategoryID");
            //     x.Property(p => p.Name);
            // });

            //  modelBuilder.Entity<PurchasedMovie>(x => {
            //     x.ToTable("PurchasedMovies").HasKey(k => k.Id);
            //     x.Property(p => p.Id).HasColumnName("PurchasedMovieID");                
            //     x.Property(p => p.Price)
            //         .HasConversion(p => p.Value, p => Dollars.Create(p).Value);
            //       x.Property(p => p.ExpirationDate)
            //          .HasConversion(p => p.Date, p => ExpirationDate.Create(p).Value);
            // });

            // modelBuilder.Entity<PurchasedMovie>(x =>
            // {
            //     x.ToTable("PurchasedMovies").HasKey(k => k.Id);
            //     x.Property(p => p.Id).HasColumnName("PurchasedMovieID");
            //     x.HasOne(p => p.Customer).WithMany(p => p.PurchasedMovies);
            //     x.HasOne(p => p.Movie).WithMany();
            // });

            // modelBuilder.Entity<Movie>(x => {
            //     x.ToTable("Movies").HasKey(k => k.Id);
            //     x.Property(p => p.Id).HasColumnName("MovieID");
            //     x.HasOne(p => p.Category).WithMany();
            // });

            // modelBuilder.Entity<Movie>()
            //     .HasDiscriminator<LicensingModel>(nameof(Movie.LicensingModel))
            //     .HasValue<TwoDaysMovie>(LicensingModel.TwoDays)
            //     .HasValue<LifeLongMovie>(LicensingModel.LifeLong);
            
            //   modelBuilder.Entity<TwoDaysMovie>()
            //  .Property(b => b.LicensingModel)
            //  .HasColumnName("LicensingModel");

            // modelBuilder.Entity<LifeLongMovie>()
            //  .Property(b => b.LicensingModel)
            // .HasColumnName("LicensingModel");
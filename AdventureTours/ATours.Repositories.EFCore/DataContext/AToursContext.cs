using ATours.Entities.POCOEntities;
using Microsoft.EntityFrameworkCore;

namespace ATours.Repositories.EFCore.DataContext
{
    public class AToursContext : DbContext
    {
        public AToursContext( DbContextOptions<AToursContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Video> Video { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Cliente>()
                .Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<Cliente>()
                .Property(n => n.LastName)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<Cliente>()
               .Property(n => n.Email)
               .IsRequired()
               .HasMaxLength(64);

            modelBuilder.Entity<Hotel>()
               .Property(n => n.Name)
               .IsRequired()
               .HasMaxLength(32);

            modelBuilder.Entity<Hotel>()
              .Property(n => n.Price)
              .IsRequired();

            modelBuilder.Entity<Hotel>()
               .Property(n => n.Place)
               .IsRequired()
               .HasMaxLength(64);


            modelBuilder.Entity<Hotel>()
              .Property(n => n.Description)
              .IsRequired()
              .HasMaxLength(1024);


            modelBuilder.Entity<Reserva>()
               .Property(n => n.ClienteId)
               .IsRequired()
               .IsFixedLength();

            modelBuilder.Entity<Reserva>()
                .HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(r => r.ClienteId);

            modelBuilder.Entity<Hotel>()
               .HasOne<Cliente>()
               .WithMany()
               .HasForeignKey(r => r.IdCliente);





        }
    }
    
}

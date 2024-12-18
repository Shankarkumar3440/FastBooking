using System;
using Microsoft.EntityFrameworkCore;



namespace Online_Booking.Models
{

    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
        {
        }

        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<Login> Login { get; set; }

        public virtual DbSet<GoogleLoginUser> GoogleLoginUser { get; set; }

        public virtual DbSet<ApplicationUsers> ApplicationUsers { get; set; }


        public virtual DbSet<RouteDetails> RouteDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
       

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("Login");

                entity.HasKey(e => e.id);

                entity.Property(e => e.id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(true);

                entity.Property(e => e.LastName)
                   .HasMaxLength(50)
                   .IsUnicode(true);

                entity.Property(e => e.MobileNo)
               .HasMaxLength(50)
               .IsUnicode(true);

                entity.Property(e => e.Email)
               .HasMaxLength(50)
               .IsUnicode(true);


                entity.Property(e => e.Address)
               .HasMaxLength(50)
               .IsUnicode(true);

                entity.Property(e => e.City)
            .HasMaxLength(50)
            .IsUnicode(true);

                entity.Property(e => e.Pincode)
          .HasMaxLength(50)
          .IsUnicode(true);

                entity.Property(e => e.Password)
          .HasMaxLength(50)
          .IsUnicode(true);

            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}

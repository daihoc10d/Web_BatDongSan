using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Web_BatDongSan.Models
{
    public partial class BDSContext : DbContext
    {
        public BDSContext()
            : base("name=BDSContext")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<DuAn> DuAns { get; set; }
        public virtual DbSet<House> Houses { get; set; }
        public virtual DbSet<ImagesDuAn> ImagesDuAns { get; set; }
        public virtual DbSet<ImagesHouse> ImagesHouses { get; set; }
        public virtual DbSet<Investor> Investors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.DuAns)
                .WithRequired(e => e.AspNetUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.Houses)
                .WithRequired(e => e.AspNetUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DuAn>()
                .HasMany(e => e.Houses)
                .WithRequired(e => e.DuAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DuAn>()
                .HasMany(e => e.ImagesDuAns)
                .WithRequired(e => e.DuAn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<House>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<House>()
                .HasMany(e => e.ImagesHouses)
                .WithRequired(e => e.House)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Investor>()
                .HasMany(e => e.DuAns)
                .WithRequired(e => e.Investor)
                .WillCascadeOnDelete(false);
        }
    }
}

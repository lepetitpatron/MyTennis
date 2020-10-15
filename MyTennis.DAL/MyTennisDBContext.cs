using Microsoft.EntityFrameworkCore;
using MyTennis.DAL.Entities;

namespace MyTennis.DAL
{
    class MyTennisDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=.\SQLEXPRESS; initial catalog=MyTennis; integrated security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Gender>().ToTable("Gender");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<League>().ToTable("League");
            modelBuilder.Entity<Member>().ToTable("Member");
            modelBuilder.Entity<Fine>().ToTable("Fine");
            modelBuilder.Entity<Game>().ToTable("Game");
            modelBuilder.Entity<Result>().ToTable("Result");

            // Set correct properties for columns
            modelBuilder.Entity<Gender>().Property(p => p.Name)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Role>().Property(p => p.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<League>().Property(p => p.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Member>().Property(p => p.FederationNr)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Member>().Property(p => p.FirstName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Member>().Property(p => p.LastName)
                .HasMaxLength(35)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Member>().Property(p => p.Address)
                .HasMaxLength(70)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Member>().Property(p => p.Number)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Member>().Property(p => p.Addition)
                .HasMaxLength(2)
                .IsUnicode(false);

            modelBuilder.Entity<Member>().Property(p => p.Zipcode)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Member>().Property(p => p.City)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Member>().Property(p => p.PhoneNr)
                .HasMaxLength(15)
                .IsUnicode(false);

            modelBuilder.Entity<Fine>().Property(p => p.FineNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Fine>().Property(p => p.Amount)
                .HasColumnType("decimal(7,2)")
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Fine>().Property(p => p.HandoutDate)
                .IsRequired();

            modelBuilder.Entity<Game>().Property(p => p.GameNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsRequired();

            modelBuilder.Entity<Game>().Property(p => p.Date)
                .IsRequired();

            modelBuilder.Entity<Result>().Property(p => p.SetNr)
               .HasMaxLength(3)
               .IsUnicode(false)
               .IsRequired();

            modelBuilder.Entity<Result>().Property(p => p.ScoreTeamMember)
               .HasMaxLength(3)
               .IsUnicode(false)
               .IsRequired();

            modelBuilder.Entity<Result>().Property(p => p.ScoreOpponent)
               .HasMaxLength(3)
               .IsUnicode(false)
               .IsRequired();

            // Set unique columns
            modelBuilder.Entity<Gender>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Role>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<League>().HasIndex(p => p.Name).IsUnique();
            modelBuilder.Entity<Member>().HasIndex(p => p.FederationNr).IsUnique();
            modelBuilder.Entity<Fine>().HasIndex(p => p.FineNumber).IsUnique();
            modelBuilder.Entity<Game>().HasIndex(p => p.GameNumber).IsUnique();

            // Many to Many relations
            
        }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
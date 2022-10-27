using DatabaseSeeder.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DatabaseSeeder.Context
{
    public partial class LibraryContext : DbContext
    {
        private string _connectionString =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public LibraryContext()
        {

        }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(b => b.Id).HasColumnName("Id");

                entity.Property(b => b.Name)
                    .HasMaxLength(64)
                    .HasColumnName("Name");

                entity.Property(b => b.AuthorId)
                    .HasColumnName("Author_Id");
                entity.HasOne(b => b.Author)
                    .WithMany(a => a.Books)
                    .HasForeignKey(b => b.AuthorId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_author");
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("Author");

                entity.Property(a => a.Id).HasColumnName("Id");
                entity.Property(a => a.Name).HasMaxLength(64).HasColumnName("Name");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

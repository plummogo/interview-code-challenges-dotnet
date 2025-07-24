using Microsoft.EntityFrameworkCore;
using OneBeyond.Core.Models;
using OneBeyondApi.Model;

namespace OneBeyondApi.DataAccess
{
    public class LibraryContext: DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookStock> Catalogue { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Reservation -> BookStock (1:N)
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.BookStock)
                .WithMany(bs => bs.Reservations)
                .HasForeignKey(r => r.BookStockId);

            // Reservation -> Borrower (1:N)
            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Borrower)
                .WithMany(b => b.Reservations)
                .HasForeignKey(r => r.BorrowerId);

            // Fine -> Borrower (1:N)
            modelBuilder.Entity<Fine>()
                .HasOne(f => f.Borrower)
                .WithMany(b => b.Fines)
                .HasForeignKey(f => f.BorrowerId);
        }
    }
}

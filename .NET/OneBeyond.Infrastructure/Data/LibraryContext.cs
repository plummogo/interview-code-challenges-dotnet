using Microsoft.EntityFrameworkCore;
using OneBeyond.Core.Models;
using OneBeyondApi.Model;

namespace OneBeyondApi.DataAccess
{
    /// <summary>
    /// LibraryContext is the Entity Framework Core DbContext for the library system.
    /// </summary>
    public class LibraryContext: DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options) { }

        /// <summary>
        /// OnConfiguring method is used to configure the DbContext options.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
        }

        // Define DbSets for the entities in the library system
        #region DbSets
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookStock> Catalogue { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<BookStock> BookStocks { get; set; }
        #endregion

        /// <summary>
        /// OnModelCreating method is used to configure the model relationships and constraints.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the one-to-many relationship between Author and Book
            modelBuilder.Entity<Reservation>()
                        .HasOne(r => r.BookStock)
                        .WithMany(bs => bs.Reservations)
                        .HasForeignKey(r => r.BookStockId);

            // Configure the one-to-many relationship between Book and Author
            modelBuilder.Entity<Reservation>()
                        .HasOne(r => r.Borrower)
                        .WithMany(b => b.Reservations)
                        .HasForeignKey(r => r.BorrowerId);

            // Configure the one-to-many relationship between Book and BookStock
            modelBuilder.Entity<Fine>()
                        .HasOne(f => f.Borrower)
                        .WithMany(b => b.Fines)
                        .HasForeignKey(f => f.BorrowerId);
        }
    }
}

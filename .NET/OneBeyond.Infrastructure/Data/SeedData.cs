using OneBeyond.Core.Dtos;
using OneBeyondApi.DataAccess;
using OneBeyondApi.Model;

namespace OneBeyondApi
{
    public static class SeedData
    {
        public static void SetInitialData(LibraryContext context)
        {
            if (context.Authors.Any())
            {
                return; // már van adat, nem seedelünk újra
            }

            var ernestMonkjack = new Author { Name = "Ernest Monkjack" };
            var sarahKennedy = new Author { Name = "Sarah Kennedy" };
            var margaretJones = new Author { Name = "Margaret Jones" };

            var clayBook = new Book
            {
                Name = "The Importance of Clay",
                Format = BookFormat.Paperback,
                Author = ernestMonkjack,
                ISBN = "1305718181"
            };

            var agileBook = new Book
            {
                Name = "Agile Project Management - A Primer",
                Format = BookFormat.Hardback,
                Author = sarahKennedy,
                ISBN = "1293910102"
            };

            var rustBook = new Book
            {
                Name = "Rust Development Cookbook",
                Format = BookFormat.Paperback,
                Author = margaretJones,
                ISBN = "3134324111"
            };

            var daveSmith = new Borrower
            {
                Name = "Dave Smith",
                EmailAddress = "dave@smithy.com"
            };

            var lianaJames = new Borrower
            {
                Name = "Liana James",
                EmailAddress = "liana@gmail.com"
            };

            var bookOnLoanUntilToday = new BookStock
            {
                Book = clayBook,
                OnLoanTo = daveSmith,
                LoanEndDate = DateTime.Now.Date
            };

            var bookNotOnLoan = new BookStock
            {
                Book = clayBook,
                OnLoanTo = null,
                LoanEndDate = null
            };

            var bookOnLoanUntilNextWeek = new BookStock
            {
                Book = agileBook,
                OnLoanTo = lianaJames,
                LoanEndDate = DateTime.Now.Date.AddDays(7)
            };

            var rustBookStock = new BookStock
            {
                Book = rustBook,
                OnLoanTo = null,
                LoanEndDate = null
            };

            context.Authors.AddRange(ernestMonkjack, sarahKennedy, margaretJones);
            context.Books.AddRange(clayBook, agileBook, rustBook);
            context.Borrowers.AddRange(daveSmith, lianaJames);
            context.Catalogue.AddRange(bookOnLoanUntilToday, bookNotOnLoan, bookOnLoanUntilNextWeek, rustBookStock);

            context.SaveChanges();
        }
    }
}

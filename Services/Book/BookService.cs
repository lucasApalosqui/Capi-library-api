using Capi_Library_Api.Data;
using Capi_Library_Api.ViewModels.Books;
using Microsoft.EntityFrameworkCore;

namespace Capi_Library_Api.Services.Book
{
    public class BookService : IBookService
    {
        public async Task<List<GetBooksViewModel>> GetAllBooks(DataContext context)
        {
            var booksFromDb = await context.Books
               .Include(x => x.Writers)
               .Include(x => x.Categories)
               .ToListAsync();

            if (booksFromDb.Count == 0)
                return null;

            return GenerateListOfBooks(booksFromDb);

            
        }

        public async Task<List<GetBooksViewModel>> GetBooksByTitle(DataContext context, string title)
        {
            var booksFromDb = await context.Books
                .AsNoTracking()
                .Include(x => x.Writers)
                .Include(x => x.Categories)
                .Where(x => x.Title.Contains(title))
                .ToListAsync();

            if (booksFromDb.Count == 0)
                return null;

            return GenerateListOfBooks(booksFromDb);

        }

        public async Task<List<GetBooksViewModel>> GetBooksByAuthor(DataContext context, string author)
        {
            var WriterFromDb = await context.Writers
                .FirstOrDefaultAsync(x => x.Name == author);

            if (WriterFromDb == null)
                return null;

            var booksFromDb = await context.Books
                .Include(x => x.Writers)
                .Include(x => x.Categories)
                .Where(x => x.Writers.Contains(WriterFromDb))
                .ToListAsync();

            if (booksFromDb.Count == 0)
                return null;

            return GenerateListOfBooks(booksFromDb);

        }

        public async Task<List<GetBooksViewModel>> GetBooksByCategory(DataContext context, string category)
        {
            var WriterFromDb = await context.Categories
                .FirstOrDefaultAsync(x => x.Name == category);

            if (WriterFromDb == null)
                return null;

            var booksFromDb = await context.Books
                .Include(x => x.Writers)
                .Include(x => x.Categories)
                .Where(x => x.Categories.Contains(WriterFromDb))
                .ToListAsync();

            if (booksFromDb.Count == 0)
                return null;

            return GenerateListOfBooks(booksFromDb);
        }

        private List<GetBooksViewModel> GenerateListOfBooks(List<Models.Book> books)
        {
            List<GetBooksViewModel> booksList = new List<GetBooksViewModel>();

            foreach (var book in books)
            {
                GetBooksViewModel bookView = new GetBooksViewModel
                {
                    Title = book.Title,
                    Sinopsis = book.Sinopsis,
                    Pages = book.Pages,
                    GeneralAud = book.GeneralAud
                };
                foreach (var category in book.Categories)
                {
                    if (category != null)
                        bookView.Categories.Add(category.Name);
                }
                foreach (var writer in book.Writers)
                {
                    if (writer != null)
                        bookView.Authors.Add(writer.Name);
                }

                booksList.Add(bookView);

            }
            return booksList;
        }
    }
}

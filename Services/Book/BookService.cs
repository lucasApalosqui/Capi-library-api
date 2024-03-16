using Capi_Library_Api.Data;
using Capi_Library_Api.ViewModels.Books;
using Microsoft.EntityFrameworkCore;

namespace Capi_Library_Api.Services.Book
{
    public class BookService : IBookService
    {
        public async Task<List<GetAllBooksViewModel>> GetAllBooks(DataContext context)
        {
            var booksFromBd = await context.Books
               .Include(x => x.Writers)
               .Include(x => x.Categories)
               .ToListAsync();

            if (booksFromBd == null)
                return null;

            List<GetAllBooksViewModel> booksList = new List<GetAllBooksViewModel>();

            foreach (var book in booksFromBd)
            {
                GetAllBooksViewModel bookView = new GetAllBooksViewModel
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

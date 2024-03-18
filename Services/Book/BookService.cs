using Capi_Library_Api.Data;
using Capi_Library_Api.Models;
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

        public async Task<CreateBookViewModel> CreateBook(DataContext context, CreateBookViewModel bookInfo)
        {
            var book = new Models.Book
            {
                Title = bookInfo.Title,
                Sinopsis = bookInfo.Sinopsis,
                Pages = bookInfo.Pages,
                GeneralAud = bookInfo.GeneralAud,
                Categories = new List<Models.Category>(),
                Writers = new List<Writer>()
            };

            foreach(var author in bookInfo.authors)
            {
                var authorVerify = await context.Writers.FirstOrDefaultAsync(x => x.Name == author);
                if(authorVerify != null)
                {
                    book.Writers.Add(authorVerify);
                }

            }

            foreach (var category in bookInfo.categories)
            {
                var categoryVerify = await context.Categories.FirstOrDefaultAsync(x => x.Name == category);
                if(categoryVerify != null) 
                {
                    book.Categories.Add(categoryVerify);
                }

            }

            if (book.Categories.Count == 0 || book.Writers.Count == 0)
                return null;

                context.Books.Add(book);


            CreateBookViewModel newBookView = new CreateBookViewModel
            {
                Title = book.Title,
                Sinopsis = book.Sinopsis,
                Pages = book.Pages,
                GeneralAud = book.GeneralAud,
                categories = bookInfo.categories,
                authors = bookInfo.authors
            };


            return newBookView;


        }

        public async Task<UpdateBookViewModel> UpdateBook(DataContext context, UpdateBookViewModel bookUpdate)
        {
            var book = await context.Books.FirstOrDefaultAsync(x => x.Id == bookUpdate.Id);

            if (book == null)
                return null;

            book.Title = bookUpdate.Title;
            book.Sinopsis = bookUpdate.Sinopsis;
            book.Pages = bookUpdate.Pages;
            book.GeneralAud = bookUpdate.GeneralAud;

            context.Books.Update(book);

            return bookUpdate;
        }

        public async Task<AddCategoryToBookViewModel> AddCategoryToBook(DataContext context, AddCategoryToBookViewModel categoryToBook)
        {
            var book = await context.Books
                .Include(x => x.Categories)
                .FirstOrDefaultAsync(x => x.Id == categoryToBook.BookId);

            if (book == null)
                return null;

            foreach(var category in categoryToBook.Categories)
            {
                var categoryVerify = await context.Categories.FirstOrDefaultAsync(x => x.Name == category);
                if (categoryVerify != null)
                    book.Categories.Add(categoryVerify);
            }

            context.Books.Update(book);

            return categoryToBook;
            
        }

        public async Task<AddAuthorToBookViewModel> AddAuthorToBook(DataContext context, AddAuthorToBookViewModel authorToBook)
        {
            var book = await context.Books
                .Include(x => x.Writers)
                .FirstOrDefaultAsync(x => x.Id == authorToBook.BookId);

            if (book == null)
                return null;

            foreach (var author in authorToBook.Authors)
            {
                var authorVerify = await context.Writers.FirstOrDefaultAsync(x => x.Name == author);
                if (authorVerify != null)
                    book.Writers.Add(authorVerify);
            }

            context.Books.Update(book);

            return authorToBook;
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

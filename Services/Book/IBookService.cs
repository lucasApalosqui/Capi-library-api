using Capi_Library_Api.Data;
using Capi_Library_Api.Models;
using Capi_Library_Api.ViewModels.Books;

namespace Capi_Library_Api.Services.Book
{
    public interface IBookService
    {
        public Task<List<GetBooksViewModel>> GetAllBooks(DataContext context);
        public Task<List<GetBooksViewModel>> GetBooksByTitle(DataContext context, string Title);
        public Task<List<GetBooksViewModel>> GetBooksByAuthor(DataContext context, string Author);
        public Task<List<GetBooksViewModel>> GetBooksByCategory(DataContext context, string Category);
        
    }
}

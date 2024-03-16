using Capi_Library_Api.Data;
using Capi_Library_Api.ViewModels.Books;

namespace Capi_Library_Api.Services.Book
{
    public interface IBookService
    {
        public Task<List<GetBooksViewModel>> GetAllBooks(DataContext context);
    }
}

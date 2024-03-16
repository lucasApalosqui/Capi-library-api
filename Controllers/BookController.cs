using Capi_Library_Api.Data;
using Capi_Library_Api.Models;
using Capi_Library_Api.Services.Book;
using Capi_Library_Api.ViewModels;
using Capi_Library_Api.ViewModels.Books;
using Capi_Library_Api.ViewModels.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capi_Library_Api.Controllers
{
    [ApiController]
    public class BookController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("v1/books")]
        public async Task<IActionResult> GetAllBooks([FromServices] DataContext context)
        {
            try
            {
                BookService bookService = new BookService();

                var booksList = await bookService.GetAllBooks(context);

                if (booksList == null)
                    return NotFound(new ResultViewModel<GetBooksViewModel>("872750 - Livros Não encontrados"));

                return Ok(new ResultViewModel<List<GetBooksViewModel>>(booksList));

            }
            catch (Exception ex)
            {
                return NotFound(new ResultViewModel<GetBooksViewModel>("872250 - Livros Não encontrados"));
            }
        }

        [AllowAnonymous]
        [HttpGet("v1/books/{title}")]
        public async Task<IActionResult> GetBooksByTitle([FromServices] DataContext context, [FromRoute] string title)
        {
            try
            {
                BookService bookService = new BookService();
                var bookListByName = await bookService.GetBooksByTitle(context, title);

                if (bookListByName == null)
                    return NotFound(new ResultViewModel<GetBooksViewModel>("872050 - Livros Não encontrados"));

                return Ok(new ResultViewModel<List<GetBooksViewModel>>(bookListByName));


            }
            catch (Exception ex)
            {
                return NotFound(new ResultViewModel<GetBooksViewModel>("878250 - Livros Não encontrados"));
            }
        }


    }
}

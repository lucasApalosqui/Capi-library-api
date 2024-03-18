﻿using Capi_Library_Api.Data;
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

        [AllowAnonymous]
        [HttpGet("v1/books/author/{author}")]
        public async Task<IActionResult> GetBooksByAuthor([FromServices] DataContext context, [FromRoute] string author)
        {
            try
            {
                BookService bookService = new BookService();
                var bookListByAuthor = await bookService.GetBooksByAuthor(context, author);

                if (bookListByAuthor == null)
                    return NotFound(new ResultViewModel<GetBooksViewModel>("87UI50 - Livros Não encontrados"));

                return Ok(new ResultViewModel<List<GetBooksViewModel>>(bookListByAuthor));


            }
            catch (Exception ex)
            {
                return NotFound(new ResultViewModel<GetBooksViewModel>("878P50 - Livros Não encontrados"));
            }
        }


        [AllowAnonymous]
        [HttpGet("v1/books/category/{category}")]
        public async Task<IActionResult> GetBooksByCategory([FromServices] DataContext context, [FromRoute] string category)
        {
            try
            {
                BookService bookService = new BookService();
                var bookListByCategory = await bookService.GetBooksByCategory(context, category);

                if (bookListByCategory == null)
                    return NotFound(new ResultViewModel<GetBooksViewModel>("87UIL0 - Livros Não encontrados"));

                return Ok(new ResultViewModel<List<GetBooksViewModel>>(bookListByCategory));

            }
            catch (Exception ex)
            {
                return NotFound(new ResultViewModel<GetBooksViewModel>("87PP50 - Livros Não encontrados"));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("v1/books")]
        public async Task<IActionResult> CreateBook([FromServices] DataContext context, [FromBody] CreateBookViewModel book)
        {
            try
            {
                BookService bookService = new BookService();
                var bookCreatedResponse = await bookService.CreateBook(context, book);

                if(bookCreatedResponse == null)
                    return NotFound(new ResultViewModel<GetBooksViewModel>("87YP50 - Autores e Categorias nao podem estar vazios!"));

                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<CreateBookViewModel>(bookCreatedResponse));

            }
            catch (Exception ex)
            {
                return NotFound(new ResultViewModel<GetBooksViewModel>("87MP50 - Erro ao criar"));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("v1/books")]
        public async Task<IActionResult> UpdateBook([FromServices] DataContext context, [FromBody] UpdateBookViewModel updateBook)
        {
            try
            {
                BookService bookService = new BookService();

                var bookUpdateResponse = await bookService.UpdateBook(context, updateBook);
                if(bookUpdateResponse == null)
                    return NotFound(new ResultViewModel<UpdateBookViewModel>("8RRR50 - livro não encontrado"));

                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<UpdateBookViewModel>(bookUpdateResponse));

            }
            catch (Exception ex)
            {
                return NotFound(new ResultViewModel<UpdateBookViewModel>("87MPTT - Erro ao atualizar"));
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("v1/books/add-category")]
        public async Task<IActionResult> AddCategoryToBook([FromServices] DataContext context, [FromBody]  AddCategoryToBookViewModel categoryToBook)
        {
            try
            {
                foreach (var category in categoryToBook.Categories)
                {
                    var categoryVerify = await context.Categories.FirstOrDefaultAsync(x => x.Name == category);
                    if (categoryVerify == null)
                        return NotFound(new ResultViewModel<AddCategoryToBookViewModel>("85JPTT - Uma ou mais categorias não cadastradas"));
                }

                BookService bookService = new BookService();
                var addCategoryToBookResponse = await bookService.AddCategoryToBook(context, categoryToBook);

                if (addCategoryToBookResponse == null)
                    return NotFound(new ResultViewModel<AddCategoryToBookViewModel>("905JPTT - Livro não encontrado"));

                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<AddCategoryToBookViewModel>(addCategoryToBookResponse));

            }
            catch (Exception ex)
            {
                return NotFound(new ResultViewModel<AddCategoryToBookViewModel>("87JPTT - Erro ao adicionar categoria"));
            }
        }

    }
}

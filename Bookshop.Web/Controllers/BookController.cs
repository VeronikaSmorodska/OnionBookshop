using Bookshop.Domain.Entities;
using Bookshop.Domain.Interfaces.Services;
using Bookshop.Service.Book.AddBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Bookshop.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private IMediator _mediator;

        public BookController(IBookService bookService, IMediator mediator)
        {
            _bookService = bookService;
            _mediator = mediator;
        }
        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            try
            {
                List<Book> books = _bookService.GetAllBooks();
                return books;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult<bool>> AddNewBook(Book book)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var vm = await _mediator.Send(new AddBookCommand { Model = book });
                    return Ok(vm);
                }
                return false;
            }
            catch(Exception ex)
            { 
                return false;
            }
        }
    }
}
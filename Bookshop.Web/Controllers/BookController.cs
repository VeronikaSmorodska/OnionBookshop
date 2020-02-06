using Bookshop.Domain.Entities;
using Bookshop.Domain.Interfaces.Services;
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
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
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
        public ActionResult<bool> AddNewBook(Book book)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _bookService.AddNewBook(book);
                    return true;
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
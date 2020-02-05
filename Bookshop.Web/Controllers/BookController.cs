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
    }
}
using Bookshop.Domain.Entities;
using Bookshop.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bookshop.Web.Conrollers
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
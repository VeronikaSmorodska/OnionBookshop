using Bookshop.Domain.Entities;
using Bookshop.Domain.Interfaces;
using Bookshop.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshop.Service.Services
{
    public class BookService:IBookService
    {
        public IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAllBooks();
        }
        public void AddNewBook(Book book)
        {
            _bookRepository.AddNewBook(book);
        }
    }
}

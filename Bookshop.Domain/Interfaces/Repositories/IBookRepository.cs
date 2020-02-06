using Bookshop.Domain.Entities;
using System.Collections.Generic;

namespace Bookshop.Domain.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        void AddNewBook(Book book);
    }
}

using Bookshop.Domain.Entities;
using System.Collections.Generic;

namespace Bookshop.Domain.Interfaces.Services
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
    }
}

using Bookshop.Domain.Entities;
using Bookshop.Domain.Interfaces;
using Bookshop.Domain.Options;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Bookshop.Repository.Repositories
{
    public class BookRepository:IBookRepository 
    {
        private readonly IOptionsSnapshot<BookshopOptions> _options;
        public BookRepository(IOptionsSnapshot<BookshopOptions> options)
        {
            _options = options;
        }
        public List<Book> GetAllBooks()
        {
            string sql = @$"SELECT * FROM [BookshopOnion].[dbo].[Book]";
            using (SqlConnection connection= new SqlConnection(_options.Value.ConnectionStrings.Main))
            {
                return connection.Query<Book>(sql).ToList();
            }
        }
        public void AddNewBook(Book book)
        {
            string sql = $@"INSERT INTO [BookshopOnion].[dbo].[Book]
                            VALUES(@BookId, @Name);";
            using(SqlConnection connection=new SqlConnection(_options.Value.ConnectionStrings.Main))
            {
                connection.Execute(sql, book);
            }
        }
    }
}

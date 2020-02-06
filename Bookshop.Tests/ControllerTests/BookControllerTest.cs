using Bookshop.Domain.Entities;
using Bookshop.Domain.Interfaces.Services;
using Bookshop.Domain.Options;
using Bookshop.Repository.Repositories;
using Bookshop.Service.Services;
using Bookshop.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTestApp.Tests
{
    public class BookControllerTest
    {

        private BookController _bookController;

        [Fact]
        public void GetAllBooksReturnsListOfBooks()
        {
            // Arrange
            var mock = new Mock<IBookService>();
            mock.Setup(s => s.GetAllBooks()).Returns(GetTestBooks());
            _bookController = new BookController(mock.Object);

            // Act
            ActionResult<List<Book>> books = _bookController.GetAllBooks();

            // Assert
            Assert.NotEqual(null, books.Value);
            Assert.Equal(4, books.Value.Count);
        }
        public List<Book> GetTestBooks()
        {
            var books = new List<Book>()
            {
                new Book{ BookId=Guid.NewGuid(), Name= "The Gunslinger" },
                new Book{ BookId=Guid.NewGuid(), Name= "Roadside Picnic" },
                new Book{ BookId=Guid.NewGuid(), Name= "Do Android Dream of Electric Ship" },
                new Book{ BookId=Guid.NewGuid(), Name= "Solaris" }
            };
            return books;
        }
        [Fact]
        public void AddBookReturnsTrueAndInvocatesServiceMethod()
        {
            //Arrange
            var mock = new Mock<IBookService>();
            _bookController = new BookController(mock.Object);
            Book newBook = new Book() { BookId = Guid.NewGuid(), Name = "Solaris" };
            //Act
            ActionResult<bool> isBookAdded = _bookController.AddNewBook(newBook);

            //Assert
            Assert.Equal(true, isBookAdded.Value);
            mock.Verify(s => s.AddNewBook(newBook));
        }
        [Fact]
        public void AddBookReturnsFase()
        {
            //Arrange
            var mock = new Mock<IBookService>();
            _bookController = new BookController(mock.Object);
            _bookController.ModelState.AddModelError("Name", "Required");
            Book newBook = new Book();

            //Act
            ActionResult<bool> isBookAdded = _bookController.AddNewBook(newBook);

            //Assert
            Assert.Equal(false, isBookAdded.Value);
        }
    }
}
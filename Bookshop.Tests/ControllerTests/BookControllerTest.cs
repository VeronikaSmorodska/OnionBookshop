using Bookshop.Domain.Entities;
using Bookshop.Domain.Interfaces.Services;
using Bookshop.Web.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
            var mockService = new Mock<IBookService>();
            var mockMerdiatR = new Mock<IMediator>();
            mockService.Setup(s => s.GetAllBooks()).Returns(GetTestBooks());
            _bookController = new BookController(mockService.Object, mockMerdiatR.Object);

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
        public async void AddBookReturnsFase()
        {
            //Arrange
            var mockService = new Mock<IBookService>();
            var mockMerdiatR = new Mock<IMediator>();
            _bookController = new BookController(mockService.Object, mockMerdiatR.Object);
            _bookController.ModelState.AddModelError("Name", "Required");
            Book newBook = new Book();

            //Act
            var isBookAdded = await _bookController.AddNewBook(newBook);

            //Assert
            Assert.Equal(false, isBookAdded.Value);
        }
    }
}
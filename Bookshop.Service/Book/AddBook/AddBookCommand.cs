using Bookshop.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bookshop.Service.Book.AddBook
{
    public class AddBookCommand:IRequest
    {
        public Domain.Entities.Book Model { get; set; }

        public class AddBookCommandHandler:IRequestHandler<AddBookCommand>
        {
            private readonly IBookRepository _bookRepository;
            public AddBookCommandHandler(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }
            public async Task<Unit> Handle(AddBookCommand request, CancellationToken token)
            {
                _bookRepository.AddNewBook(request.Model);
                return Unit.Value;
            }

        }
    }
}

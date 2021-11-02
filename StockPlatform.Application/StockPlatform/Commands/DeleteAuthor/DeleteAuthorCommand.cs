using MediatR;
using System;

namespace StockPlatform.Application.StockPlatform.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand : IRequest
    {
        public Guid AuthorId { get; set; }
    }
}

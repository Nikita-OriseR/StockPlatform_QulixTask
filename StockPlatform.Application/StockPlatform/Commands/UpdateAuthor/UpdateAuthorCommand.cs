using MediatR;
using System;

namespace StockPlatform.Application.StockPlatform.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand : IRequest
    {
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
    }
}

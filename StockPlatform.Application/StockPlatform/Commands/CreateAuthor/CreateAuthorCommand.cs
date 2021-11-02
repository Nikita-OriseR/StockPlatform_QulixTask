using MediatR;
using System;

namespace StockPlatform.Application.StockPlatform.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest<Guid>
    {
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public DateTime AccountСreationDate { get; set; }
    }
}

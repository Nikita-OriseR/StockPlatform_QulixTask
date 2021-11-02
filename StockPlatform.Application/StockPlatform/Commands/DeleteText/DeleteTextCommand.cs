using MediatR;
using System;

namespace StockPlatform.Application.StockPlatform.Commands.DeleteText
{
    public class DeleteTextCommand : IRequest
    {
        public Guid TextId { get; set; }
    }
}

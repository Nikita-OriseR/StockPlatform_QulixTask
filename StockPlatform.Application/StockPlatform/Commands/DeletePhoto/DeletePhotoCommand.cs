using MediatR;
using System;

namespace StockPlatform.Application.StockPlatform.Commands.DeletePhoto
{
    public class DeletePhotoCommand : IRequest
    {
        public Guid PhotoId { get; set; }
    }
}

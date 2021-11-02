using MediatR;
using System;

namespace StockPlatform.Application.StockPlatform.Commands.UpdatePhoto
{
    public class UpdatePhotoCommand : IRequest
    {
        public Guid PhotoId { get; set; }
        public string Title { get; set; }
        public string ContentLink { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Cost { get; set; }
        public int NumberPurchases { get; set; }
    }
}

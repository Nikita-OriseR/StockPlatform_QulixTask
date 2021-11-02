using MediatR;
using StockPlatform.Domain;
using System;

namespace StockPlatform.Application.StockPlatform.Commands.CreatePhoto
{
    public class CreatePhotoCommand : IRequest<Guid>
    {
        public Guid PhotoId { get; set; }
        public string Title { get; set; }
        public string ContentLink { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public DateTime CreationDate { get; set; }
        public Author Author { get; set; }
        public double Cost { get; set; }
        public int NumberPurchases { get; set; }
    }
}

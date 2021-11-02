using MediatR;
using System;

namespace StockPlatform.Application.StockPlatform.Commands.UpdateText
{
    public class UpdateTextCommand : IRequest
    {
        public Guid TextId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Size { get; set; }
        public double Cost { get; set; }
        public int NumberPurchases { get; set; }
    }
}

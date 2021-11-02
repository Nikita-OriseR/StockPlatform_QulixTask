using MediatR;
using StockPlatform.Domain;
using System;

namespace StockPlatform.Application.StockPlatform.Commands.CreateText
{
    public class CreateTextCommand : IRequest<Guid>
    {
        public Guid TextId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Size { get; set; }
        public DateTime CreationDate { get; set; }
        public double Cost { get; set; }
        public Author Author { get; set; }
        public int NumberPurchases { get; set; }
    }
}

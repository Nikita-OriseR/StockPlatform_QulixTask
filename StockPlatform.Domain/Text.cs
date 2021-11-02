using System;

namespace StockPlatform.Domain
{
    public class Text
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

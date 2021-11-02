using System;

namespace StockPlatform.Domain
{
    public class Author
    {
        public Guid AuthorId { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public int Age { get; set; }
        public DateTime AccountСreationDate { get; set; }
    }
}

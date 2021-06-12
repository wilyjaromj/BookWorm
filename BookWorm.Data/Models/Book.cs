using System;

namespace BookWorm.Data
{
    public class Book
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Author { get; set; }
        public virtual byte[] CoverArt { get; set; }
        public virtual string Description { get; set; }
        public virtual int Rating { get; set; }
        public virtual string Series { get; set; }
    }
}

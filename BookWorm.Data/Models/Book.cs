using System.ComponentModel.DataAnnotations;

namespace BookWorm.Data
{
    public class Book
    {
        public virtual int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public virtual string Title { get; set; }
        [Required]
        [MaxLength(150)]
        public virtual string Author { get; set; }
        public virtual byte[] CoverArt { get; set; }
        [MaxLength(2500)]
        public virtual string Description { get; set; }
        public virtual int Rating { get; set; }
        [MaxLength(200)]
        public virtual string Series { get; set; }
    }
}

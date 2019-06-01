using System;
using System.ComponentModel.DataAnnotations;

namespace ArticlesApp.Model
{
    public class Review
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        [Range(0,5)]
        public byte NumStars { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }
    }
}

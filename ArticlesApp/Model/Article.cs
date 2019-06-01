using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArticlesApp.Model
{
    public class Article
    {
        public int Id { get; set; }
        [Required, StringLength(255,MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}

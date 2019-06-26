using System;
using System.ComponentModel.DataAnnotations;

namespace ArticlesApp.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        [Range(0, 5)]
        public byte NumStars { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}

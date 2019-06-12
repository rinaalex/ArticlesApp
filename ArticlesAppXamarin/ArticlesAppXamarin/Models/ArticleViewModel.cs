using System;

namespace ArticlesAppXamarin.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        public string AuthorName { get; set; }
        public float Raiting { get; set; }
    }
}

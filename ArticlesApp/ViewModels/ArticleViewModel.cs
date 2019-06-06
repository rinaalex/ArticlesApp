using System;
using System.ComponentModel.DataAnnotations;

namespace ArticlesApp.ViewModels
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        public string AuthorName { get; set; }
        [DisplayFormat(DataFormatString ="0:#.#")]
        public float Raiting { get; set; }
    }
}

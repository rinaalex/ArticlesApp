using System;
using System.ComponentModel.DataAnnotations;

namespace ArticlesApp.ViewModels.Articles
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Необходимо ввести заголовок статьи!")]
        [StringLength(255, MinimumLength = 3, ErrorMessage = "Заголовок должен содержать не менее 3 символов!")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Необходимо ввести текст статьи!")]
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        public string AuthorName { get; set; }
        [DisplayFormat(DataFormatString ="0:#.#")]
        public float Raiting { get; set; }
    }
}

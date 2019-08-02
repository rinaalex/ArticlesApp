using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesAppMobile.BL.ViewModels.Articles
{
    public class ArticleViewModel: BaseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        public string AuthorName { get; set; }
        public float Raiting { get; set; }
    }
}

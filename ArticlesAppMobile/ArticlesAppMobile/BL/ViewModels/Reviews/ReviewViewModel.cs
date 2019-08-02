using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesAppMobile.BL.ViewModels.Reviews
{
    public class ReviewViewModel: BaseViewModel
    {
        public int Id { get; set; }
        public string ArticleName { get; set; }
        public string Content { get; set; }
        public byte NumStars { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}

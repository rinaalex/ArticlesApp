using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesAppMobile.BL.ViewModels.Authors
{
    public class AuthorViewModel: BaseViewModel
    {
        public string Username { get; set; }
        public int NumOfArticles { get; set; }
        public float Raiting { get; set; }
    }
}

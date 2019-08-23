using System.ComponentModel.DataAnnotations;

namespace ArticlesApp.ViewModels.Authors
{
    public class AuthorViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int NumOfArticles { get; set; }
        [DisplayFormat(DataFormatString = "0:#.#")]
        public float Raiting { get; set; }
    }
}

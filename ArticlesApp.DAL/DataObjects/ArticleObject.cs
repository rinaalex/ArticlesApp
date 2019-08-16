using System;

namespace ArticlesApp.DAL.DataObjects
{
    public class ArticleObject: BaseDataObject
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublicationDate { get; set; }
        public string AuthorName { get; set; }
        public float Raiting { get; set; }
    }
}

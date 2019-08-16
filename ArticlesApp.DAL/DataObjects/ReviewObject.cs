using System;

namespace ArticlesApp.DAL.DataObjects
{
    public class ReviewObject: BaseDataObject
    {
        public string ArticleName { get; set; }
        public string Content { get; set; }
        public byte NumStars { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublicationDate { get; set; }
    }
}

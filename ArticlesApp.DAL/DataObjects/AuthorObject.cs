namespace ArticlesApp.DAL.DataObjects
{
    public class AuthorObject: BaseDataObject
    {
        public string Username { get; set; }
        public int NumOfArticles { get; set; }
        public float Raiting { get; set; }
    }
}

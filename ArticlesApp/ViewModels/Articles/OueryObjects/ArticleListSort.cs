using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace ArticlesApp.ViewModels.Articles.QueryObjects
{
    public enum ArciclesOrderByOptions
    {
        [Display(Name = "Сортировать..")]
        SimpleOrder=0,
        [Display(Name = "по заголовку ↑")]
        ByTitle,
        [Display(Name = "по заголовку ↓")]
        ByTitleDesc,
        [Display(Name = "по дате публикации ↑")]
        ByPublicationDate,
        [Display(Name = "по дате публикации ↓")]
        ByPublicationDateDesc,
        [Display(Name = "по рейтингу ↑")]
        ByRaiting,
        [Display(Name = "по рейтингу ↓")]
        byRaitingDesc
    }

    /// <summary>
    /// Выполняет сортировку коллекции ArticleViewModel
    /// </summary>
    public static class ArticleListSort
    {
        /// <summary>
        /// Содержит сопоставление ключей сортировки 
        /// </summary>
        public static Dictionary<string, ArciclesOrderByOptions> OrderDictionary = new Dictionary<string, ArciclesOrderByOptions>();

        static ArticleListSort()
        {
            OrderDictionary.Add("none", ArciclesOrderByOptions.SimpleOrder);
            OrderDictionary.Add("title", ArciclesOrderByOptions.ByTitle);
            OrderDictionary.Add("-title", ArciclesOrderByOptions.ByTitleDesc);
            OrderDictionary.Add("date", ArciclesOrderByOptions.ByPublicationDate);
            OrderDictionary.Add("-date", ArciclesOrderByOptions.ByPublicationDateDesc);
            OrderDictionary.Add("raiting", ArciclesOrderByOptions.ByRaiting);
            OrderDictionary.Add("-raiting", ArciclesOrderByOptions.byRaitingDesc);
        }        

        public static IEnumerable<ArticleViewModel>OrderArticlesBy(
            this IEnumerable<ArticleViewModel> articles, ArciclesOrderByOptions orderByOptions)
        {
            switch(orderByOptions)
            {
                case ArciclesOrderByOptions.SimpleOrder:
                    return articles.OrderBy(a => a.Id);
                case ArciclesOrderByOptions.ByTitle:
                    return articles.OrderBy(a => a.Title);
                case ArciclesOrderByOptions.ByTitleDesc:
                    return articles.OrderByDescending(a => a.Title);
                case ArciclesOrderByOptions.ByPublicationDate:
                    return articles.OrderBy(a => a.PublicationDate);
                case ArciclesOrderByOptions.ByPublicationDateDesc:
                    return articles.OrderByDescending(a => a.PublicationDate);
                case ArciclesOrderByOptions.ByRaiting:
                    return articles.OrderBy(a => a.Raiting);
                case ArciclesOrderByOptions.byRaitingDesc:
                    return articles.OrderByDescending(a => a.Raiting);
                default: return articles.OrderBy(a => a.Id);
            }
        }

        /// <summary>
        /// Выполняет преобразование строки в параметр сортировки
        /// </summary>
        /// <param name="key">Ключ сортировки</param>
        /// <returns>Параметр сортировки</returns>
        public static ArciclesOrderByOptions ParseOrderByOptions(string key)
        {
            if(OrderDictionary.ContainsKey(key))
            {
                return OrderDictionary[key];
            }
            return ArciclesOrderByOptions.SimpleOrder;
        }
    }
}

using System.Collections.Generic;
using System.Linq;

namespace ArticlesApp.ViewModels.Authors.QueryObjects
{
    public enum AuthorOrderByOptions
    {
        Simple = 0,
        ByName,
        ByNameDesc,
        ByRaiting,
        ByRaitingDesc,
        ByNumOfArticles,
        ByNumOfArticlesDesc
    }    

    /// <summary>
    /// Выполняет сортирвку коллекции AuthorViewModel
    /// </summary>
    public static class AuthorListSort
    {
        /// <summary>
        /// Содержит сопоставление ключей сортировки
        /// </summary>
        public static Dictionary<string, AuthorOrderByOptions> OrderDictionary = new Dictionary<string, AuthorOrderByOptions>();

        static AuthorListSort()
        {
            OrderDictionary.Add("none", AuthorOrderByOptions.Simple);
            OrderDictionary.Add("name", AuthorOrderByOptions.ByName);
            OrderDictionary.Add("-name", AuthorOrderByOptions.ByNameDesc);
            OrderDictionary.Add("raiting", AuthorOrderByOptions.ByRaiting);
            OrderDictionary.Add("-raiting", AuthorOrderByOptions.ByRaitingDesc);
            OrderDictionary.Add("articles", AuthorOrderByOptions.ByNumOfArticles);
            OrderDictionary.Add("-articles", AuthorOrderByOptions.ByNumOfArticlesDesc);
        }

        public static IEnumerable<AuthorViewModel>OrderAuthorsBy(this IEnumerable<AuthorViewModel> authors, AuthorOrderByOptions orderByOptions)
        {
            switch(orderByOptions)
            {
                case AuthorOrderByOptions.ByName:
                    return authors.OrderBy(a => a.Username);
                case AuthorOrderByOptions.ByNameDesc:
                    return authors.OrderByDescending(a => a.Username);
                case AuthorOrderByOptions.ByRaiting:
                    return authors.OrderBy(a => a.Raiting);
                case AuthorOrderByOptions.ByRaitingDesc:
                    return authors.OrderByDescending(a => a.Raiting);
                case AuthorOrderByOptions.ByNumOfArticles:
                    return authors.OrderBy(a => a.NumOfArticles);
                case AuthorOrderByOptions.ByNumOfArticlesDesc:
                    return authors.OrderByDescending(a => a.NumOfArticles);
                case AuthorOrderByOptions.Simple:  default:
                    return authors;
            }
        }

        /// <summary>
        /// Выполняет преобразование строки в параметр сортировки
        /// </summary>
        /// <param name="key">Ключ сортировки</param>
        /// <returns>Параметр сортировки</returns>
        public static AuthorOrderByOptions ParseOrderByOptions(string key)
        {
            if(OrderDictionary.ContainsKey(key))
            {
                return OrderDictionary[key];
            }
            return AuthorOrderByOptions.Simple;
        }
    }
}

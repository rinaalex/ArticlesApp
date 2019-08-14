using System;
using System.Windows.Input;
using Xamarin.Forms;

using ArticlesAppMobile.UI.Pages.Articles;
using ArticlesAppMobile.UI.Pages.Reviews;

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

        public ICommand EditArticleCommand { get; set; }
        public ICommand AddReviewCommand { get; set; }
        public ICommand ShowReviewsCommand { get; set; }

        public ArticleViewModel()
        {
            EditArticleCommand = new Command(EditArticle);
            AddReviewCommand = new Command(AddReview);
            ShowReviewsCommand = new Command(ShowReviews);
        }

        public async void EditArticle()
        {
            // Добавить передачу ид редактируемой статьи
            EditArticlePage editArticlePage = new EditArticlePage();
            await Navigation.PushAsync(editArticlePage);
        }

        public async void AddReview()
        {
            // Добавить передачу ид статьи
            AddReviewPage addReviewPage = new AddReviewPage();
            await Navigation.PushAsync(addReviewPage);
        }

        public async void ShowReviews()
        {
            // Добавить передачу ид статьи
            ReviewsListPage reviewsListPage = new ReviewsListPage();
            await Navigation.PushAsync(reviewsListPage);
        }
    }
}

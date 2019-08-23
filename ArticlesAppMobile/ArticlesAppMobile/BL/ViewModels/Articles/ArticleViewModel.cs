using System.Windows.Input;
using Xamarin.Forms;
using ArticlesAppMobile.UI.Pages.Articles;
using ArticlesAppMobile.UI.Pages.Reviews;
using ArticlesApp.DAL.DataObjects;
using ArticlesApp.DAL.DataServices;

namespace ArticlesAppMobile.BL.ViewModels.Articles
{
    public class ArticleViewModel: BaseViewModel
    {
        public ArticleObject Article
        {
            get => Get<ArticleObject>();
            set => Set(value);
        }

        public ICommand EditArticleCommand { get; set; }
        public ICommand AddReviewCommand { get; set; }
        public ICommand ShowReviewsCommand { get; set; }

        public ArticleViewModel(int articleId)
        {
            EditArticleCommand = new Command(EditArticle);
            AddReviewCommand = new Command(AddReview);
            ShowReviewsCommand = new Command(ShowReviews);

            LoadData(articleId);
        }

        async void LoadData(int articleId)
        {
            Article = await DataServices.Articles.GetArticle(articleId);
        }

        public async void EditArticle()
        {
            EditArticlePage editArticlePage = new EditArticlePage(Article.Id);
            await Navigation.PushAsync(editArticlePage);
        }

        public async void AddReview()
        {
            // Добавить передачу ид статьи
            AddReviewPage addReviewPage = new AddReviewPage(Article.Id);
            await Navigation.PushAsync(addReviewPage);
        }

        public async void ShowReviews()
        {
            ReviewsListPage reviewsListPage = new ReviewsListPage(Article.Id);
            await Navigation.PushAsync(reviewsListPage);
        }
    }
}

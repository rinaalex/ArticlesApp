using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ArticlesAppXamarin.Models;

using ArticlesAppXamarin.Services;
using Refit;

namespace ArticlesAppXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticlesListPage : ContentPage
    {
        public ArticlesListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            //listView.ItemsSource = await App.ArticleManager.GetTasksAsync();
            var response = RestService.For<IArticlesApi>(Constants.BaseAddress);
            var articles = await response.GetArticles();
            listView.ItemsSource = articles;
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ArticlePage
            {
                BindingContext = (ArticleModel)e.SelectedItem
            });
        }
    }
}
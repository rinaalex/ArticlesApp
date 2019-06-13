using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ArticlesAppXamarin.Models;

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
            listView.ItemsSource = await App.ArticleManager.GetTasksAsync();
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ArticlePage
            {
                BindingContext = (ArticleViewModel)e.SelectedItem
            });
        }
    }
}
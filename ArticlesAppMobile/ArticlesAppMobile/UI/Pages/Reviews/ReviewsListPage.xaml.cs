using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ArticlesAppMobile.BL.ViewModels.Reviews;

namespace ArticlesAppMobile.UI.Pages.Reviews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReviewsListPage : ContentPage
    {
        public ReviewsListPage(int articleId)
        {
            InitializeComponent();
            BindingContext = new ReviewsListViewModel(articleId) { Navigation = this.Navigation };
        }
    }
}
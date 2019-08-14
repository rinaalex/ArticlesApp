using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ArticlesAppMobile.BL.ViewModels.Articles;

namespace ArticlesAppMobile.UI.Pages.Articles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArticlesListPage : ContentPage
    {
        public ArticlesListPage()
        {
            InitializeComponent();
            BindingContext = new ArticleListViewModel { Navigation = this.Navigation };
        }
    }
}
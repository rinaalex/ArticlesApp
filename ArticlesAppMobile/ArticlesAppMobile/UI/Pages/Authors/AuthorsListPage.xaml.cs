using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using ArticlesAppMobile.BL.ViewModels.Authors;

namespace ArticlesAppMobile.UI.Pages.Authors
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuthorsListPage : ContentPage
    {
        public AuthorsListPage()
        {
            InitializeComponent();
            BindingContext = new AuthorsListViewModel { Navigation = this.Navigation };
        }
    }
}
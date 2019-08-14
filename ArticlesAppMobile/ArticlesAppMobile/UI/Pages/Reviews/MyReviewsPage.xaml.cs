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
    public partial class MyReviewsPage : ContentPage
    {
        public MyReviewsPage()
        {
            InitializeComponent();
            BindingContext = new MyReviewsViewModel { Navigation = this.Navigation };
        }
    }
}
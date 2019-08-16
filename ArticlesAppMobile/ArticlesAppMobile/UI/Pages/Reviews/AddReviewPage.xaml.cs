﻿using System;
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
    public partial class AddReviewPage : ContentPage
    {
        public AddReviewPage()
        {
            InitializeComponent();
            BindingContext = new AddReviewViewModel { Navigation = this.Navigation };
        }
    }
}
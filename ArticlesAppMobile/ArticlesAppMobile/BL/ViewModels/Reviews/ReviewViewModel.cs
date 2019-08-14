﻿using System;
using System.Windows.Input;
using Xamarin.Forms;

using ArticlesAppMobile.UI.Pages.Reviews;

namespace ArticlesAppMobile.BL.ViewModels.Reviews
{
    public class ReviewViewModel: BaseViewModel
    {
        public int Id { get; set; }
        public string ArticleName { get; set; }
        public string Content { get; set; }
        public byte NumStars { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublicationDate { get; set; }

        public ICommand EditReviewCommand { get; set; }

        public ReviewViewModel()
        {
            EditReviewCommand = new Command(EditReview);
        }

        public async void EditReview()
        {
            EditReviewPage editReviewPage = new EditReviewPage();
            await Navigation.PushAsync(editReviewPage);
        }
    }
}

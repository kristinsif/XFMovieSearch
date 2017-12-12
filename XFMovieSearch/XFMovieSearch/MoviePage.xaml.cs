using System;
using System.Collections.Generic;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class MoviePage : ContentPage
    {
        public MoviePage(Movie movie)
        {
            this.BindingContext = movie;
            InitializeComponent();
        }
    }
}

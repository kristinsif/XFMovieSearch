using System;
using System.Collections.Generic;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class MovieListPage : ContentPage
    {
        public MovieListPage(List<Movie> movie)
        {
            this.BindingContext = new MovieListViewModel(this.Navigation, movie);
            InitializeComponent();
        }
    }
}

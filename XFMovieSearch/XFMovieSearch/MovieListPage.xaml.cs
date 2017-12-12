using System;
using System.Collections.Generic;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class MovieListPage : ContentPage
    {
        public MovieListPage(List<Movie> movieList, List<MovieDetail> movieDetailList)
        {
            this.BindingContext = new MovieListViewModel(this.Navigation, movieList, movieDetailList);
            InitializeComponent();
        }
    }
}
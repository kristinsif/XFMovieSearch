using System;
using System.Collections.Generic;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class MoviePage : ContentPage
    {
        private MovieDetail _movieDetail;
        public MoviePage(Movie movie, List<MovieDetail> movieDetailList)
        {
            foreach (var m in movieDetailList)
            {
                if (m.Title == movie.Title && movie.Year == m.Year)
                {
                    this._movieDetail = m;
                    break;
                }
            }
            this.BindingContext = this._movieDetail;
            InitializeComponent();
        }
    }
}
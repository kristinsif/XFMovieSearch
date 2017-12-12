using System;
using System.Collections.Generic;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class XFMovieSearchPage : ContentPage
    {
        private MovieServices _movieService;
        private List<Movie> _movieList;
        private List<MovieDetail> _movieDetailList;

        public XFMovieSearchPage(MovieServices movieService, List<Movie> movieList, List<MovieDetail> movieDetailList)
        {
            this._movieService = movieService;
            this._movieList = movieList;
            this._movieDetailList = movieDetailList;
            InitializeComponent();
        }

        private async void GetMoviesButton_OnClicked(object sender, EventArgs e)
        {
            this.Spinner.IsRunning = true;
            this._movieList = await _movieService.getListOfMoviesMatchingSearch(MovieEntry.Text);
            this._movieDetailList = await _movieService.getListOfMovieDetails(this._movieList);
            await this.Navigation.PushAsync(new MovieListPage(this._movieList, this._movieDetailList));
            this.Spinner.IsRunning = false;

        }
    }
}
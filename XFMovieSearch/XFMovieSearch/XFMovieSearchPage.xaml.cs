using System;
using System.Collections.Generic;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class XFMovieSearchPage : ContentPage
    {
        private MovieServices _movieService;
        private List<Movie> _movie;

        public XFMovieSearchPage(MovieServices movieService, List<Movie> movie)
        {
            this._movieService = movieService;
            this._movie = movie;
            InitializeComponent();
        }

        private async void GetMoviesButton_OnClicked(object sender, EventArgs e)
        {
            this.Spinner.IsRunning = true;
            this._movie = await _movieService.getListOfMoviesMatchingSearch(MovieEntry.Text);
            await this.Navigation.PushAsync(new MovieListPage(this._movie));
            this.Spinner.IsRunning = false;

        }
    }
}

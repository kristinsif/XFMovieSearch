using System;
using System.Collections.Generic;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class XFMovieSearchPage : ContentPage
    {
        private MovieServices _movieService;
        private MovieListViewModel _viewModel;

        public XFMovieSearchPage(MovieServices movieService)
        {
            this._movieService = movieService;
            this._viewModel = new MovieListViewModel(this.Navigation, this._movieService);
            this.BindingContext = this._viewModel;
            InitializeComponent();
        }

        private async void OnSearchBarButtonPressed(object sender, EventArgs args)
        {
            this.Spinner.IsRunning = true;
            this._viewModel.Movie = await _movieService.getListOfMoviesMatchingSearch(MovieEntry.Text);
            this.Spinner.IsRunning = false;
            this._viewModel.Movie = await this._viewModel.LoadCast();
            InitializeComponent();
        }

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            this.ListView.SelectedItem = null;
        }

    }
}
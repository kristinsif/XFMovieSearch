using System;
using System.Collections.Generic;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class PopularMoviesPage : ContentPage
    {
        private MovieServices _movieService;
        private MovieListViewModel _viewModel;

        public PopularMoviesPage(MovieServices movieService)
        {
            this._movieService = movieService;
            this._viewModel = new MovieListViewModel(this.Navigation, this._movieService);
            this.BindingContext = this._viewModel;
            InitializeComponent();
        }

        public void LoadPopularMovies()
        {
            this._viewModel.LoadPopularMovies();

        }

        /*protected override async void OnAppearing()
        {
            base.OnAppearing();
            this._movieList = await _movieService.getListOfPopularMovies();
            await this.Navigation.PushAsync(new MovieListPage(this._movieList, this._movieService));
        }*/
    }
}
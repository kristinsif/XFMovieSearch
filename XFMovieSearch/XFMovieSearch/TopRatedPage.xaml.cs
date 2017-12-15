using System;
using System.Collections.Generic;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class TopRatedPage : ContentPage
    {
        private MovieServices _movieService;
        private MovieListViewModel _viewModel;

        public TopRatedPage(MovieServices movieService)
        {
            this._movieService = movieService;
            this._viewModel = new MovieListViewModel(this.Navigation, this._movieService);
            this.BindingContext = this._viewModel;
            InitializeComponent();
        }

        public void LoadTopRatedMovies()
        {
            this._viewModel.LoadTopRatedMovies();
        }

        void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            this.ListView.SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            this._viewModel.Movie = await this._viewModel.LoadCast();
            InitializeComponent();
        }
    }
}
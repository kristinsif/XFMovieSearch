using System;
using System.Collections.Generic;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class MovieListPage : ContentPage
    {
        private List<Movie> _movieList;
        private MovieServices _movieService;
        private MovieListViewModel _viewModel;

        public MovieListPage(List<Movie> movieList, MovieServices movieService)
        {

            this._movieList = movieList;
            this._movieService = movieService;
            this._viewModel = new MovieListViewModel(this.Navigation, this._movieService);
            this.BindingContext = this._viewModel;
            InitializeComponent();
        }


        //protected override async void OnAppearing()
       // {
           // base.OnAppearing();

          //  this._movieList = await this._viewModel.LoadCast();
         //   InitializeComponent();

            /*foreach(var movie in this._movieList){
                movie.Actors = await _movieService.GetActors(movie);
                InitializeComponent();
            }*/
            //this._movieList = await _movieService.GetActorsForList(this._movieList);

       // }
    }
}
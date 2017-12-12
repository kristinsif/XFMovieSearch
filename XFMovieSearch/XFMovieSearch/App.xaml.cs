using System.Collections.Generic;
using DM.MovieApi;
using DM.MovieApi.MovieDb.Movies;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MovieDbFactory.RegisterSettings(new MovieDbSettings());
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            var movieService = new MovieServices(movieApi);

            MainPage = new NavigationPage(new XFMovieSearchPage(movieService, new List<MovieDatabase.Movie>(), new List<MovieDetail>()));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
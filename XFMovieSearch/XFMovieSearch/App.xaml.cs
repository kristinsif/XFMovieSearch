using System.Collections.Generic;
using DM.MovieApi;
using DM.MovieApi.MovieDb.Movies;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public partial class App : Application
    {

        private MovieServices _movieService;
        private TopRatedPage _topRatedPage;
        private PopularMoviesPage _popularMoviesPage;
        private TabbedPage _tabbedPage;

        public App()
        {
            InitializeComponent();

            MovieDbFactory.RegisterSettings(new MovieDbSettings());
            var movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
            this._movieService = new MovieServices(movieApi);

            var moviePage = new XFMovieSearchPage(this._movieService);
            var movieNavigationPage = new NavigationPage(moviePage);
            movieNavigationPage.Title = "Search";

            this._topRatedPage = new TopRatedPage(this._movieService);
            var topRatedNavigationPage = new NavigationPage(this._topRatedPage);
            topRatedNavigationPage.Title = "Top Rated";

            this._popularMoviesPage = new PopularMoviesPage(this._movieService);
            var popularNavigationPage = new NavigationPage(this._popularMoviesPage);
            popularNavigationPage.Title = "Popular movies";

            this._tabbedPage = new TabPage(this._topRatedPage, this._popularMoviesPage);
            this._tabbedPage.Children.Add(movieNavigationPage);
            this._tabbedPage.Children.Add(topRatedNavigationPage);
            this._tabbedPage.Children.Add(popularNavigationPage);


            MainPage = this._tabbedPage;
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
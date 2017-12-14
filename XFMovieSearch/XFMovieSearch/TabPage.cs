using System;
using Xamarin.Forms;
namespace XFMovieSearch
{
    public class TabPage : TabbedPage
    {
        private TopRatedPage _topRatedPage;
        private PopularMoviesPage _popularMovies;

        public TabPage(TopRatedPage topRatedPage, PopularMoviesPage popularMoviesPage)
        {
            this._topRatedPage = topRatedPage;
            this._popularMovies = popularMoviesPage;

        }

        protected override void OnAppearing()
        {
            this._topRatedPage.LoadTopRatedMovies();
            this._popularMovies.LoadPopularMovies();
        }

    }
}
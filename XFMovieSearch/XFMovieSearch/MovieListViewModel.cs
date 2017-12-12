using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MovieDatabase;
using Xamarin.Forms;

namespace XFMovieSearch
{
    public class MovieListViewModel : INotifyPropertyChanged
    {
        private INavigation _navigation;
        private Movie _selectedMovie;
        private List<Movie> _movieList;
        private List<MovieDetail> _movieDetailList;

        public MovieListViewModel(INavigation navigation, List<Movie> movieList, List<MovieDetail> movieDetailList)
        {
            this._navigation = navigation;
            this._movieList = movieList;
            this._movieDetailList = movieDetailList;
        }

        public List<Movie> Movie
        {
            get => this._movieList;

            set
            {
                this._movieList = value;
                OnPropertyChanged();
            }
        }

        public List<MovieDetail> MovieDetail
        {
            get => this._movieDetailList;

            set
            {
                this._movieDetailList = value;
                OnPropertyChanged();
            }
        }

        public Movie SelectedMovie
        {
            get => this._selectedMovie;

            set
            {
                if (value != null)
                {
                    this._selectedMovie = value;
                    this._navigation.PushAsync(new MoviePage(this._selectedMovie, this._movieDetailList), true);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
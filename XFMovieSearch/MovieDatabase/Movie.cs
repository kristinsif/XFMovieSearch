using DM.MovieApi.MovieDb.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using DM.MovieApi.MovieDb.Genres;

namespace MovieDatabase
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Actors { get; set; }
        public string ImageUrl { get; set; }
        public ImageSource ImageSource => ImageSource.FromUri(new Uri("https://image.tmdb.org/t/p/w500" + this.ImageUrl));
        public IReadOnlyList<Genre> Genre { get; set; }
        public string Genres { get; set; }
        public string RunningTime { get; set; }
        public string Overview { get; set; }

    }
}
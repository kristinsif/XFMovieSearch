using DM.MovieApi.MovieDb.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace MovieDatabase
{
    public class MovieDetail
    {
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public IReadOnlyList<Genre> Genre  { get; set; }
        public string RunningTime { get; set; }
        public string ImageUrl { get; set; }
        public string LocalImagePath { get; set; }
        public string Overview { get; set; }
        public ImageSource ImageSource => ImageSource.FromUri(new Uri("https://image.tmdb.org/t/p/w500" + this.ImageUrl));

    }
}

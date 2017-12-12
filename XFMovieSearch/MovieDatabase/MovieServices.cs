using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase
{
    public class MovieServices
    {
        private IApiMovieRequest _movieApi;
        //private int i = 0;

        public MovieServices(IApiMovieRequest movieApi)
        {
            _movieApi = movieApi;
        }

        public async Task<List<Movie>> getListOfMoviesMatchingSearch(string nameField)
        {
            List<Movie> responseMovieList = new List<Movie>();           

            if (nameField.Length == 0)
            {
                return responseMovieList;
            }
            else
            {
                ApiSearchResponse<MovieInfo> response = await _movieApi.SearchByTitleAsync(nameField);
                foreach (MovieInfo info in response.Results)
                {
                    ApiQueryResponse<MovieCredit> cast = await _movieApi.GetCreditsAsync(info.Id);
                    List<string> actors = new List<string>();
                    
                    int number = 3;

                    if (cast.Item.CastMembers.Count < 3)
                    {
                        number = cast.Item.CastMembers.Count;
                    }
                    for (int i = 0; i < number; i++)
                    {                   
                        actors.Add(cast.Item.CastMembers[i].Name);
                       
                    }

                    responseMovieList.Add(new Movie() { Id = info.Id, Title = info.Title, Year = info.ReleaseDate, Actors = actors, ImageUrl = info.PosterPath});
                }
            }
            return responseMovieList;
        }


        public async Task<List<Movie>> getListOfTopRatedMovies()
        {
            List<Movie> responseMovieList = new List<Movie>();
            ApiSearchResponse<MovieInfo> response = await _movieApi.GetTopRatedAsync(1);
            foreach (MovieInfo info in response.Results)
            {
                ApiQueryResponse<MovieCredit> cast = await _movieApi.GetCreditsAsync(info.Id);
                List<string> actors = new List<string>();
                int number = 3;
                if (cast.Item.CastMembers.Count < 3)
                {
                    number = cast.Item.CastMembers.Count;
                }
                for (int i = 0; i < number; i++)
                {
                    actors.Add(cast.Item.CastMembers[i].Name);
                }

                responseMovieList.Add(new Movie() { Id = info.Id, Title = info.Title, Year = info.ReleaseDate, Actors = actors, ImageUrl = info.PosterPath });
            }

            return responseMovieList;
        }

       

       /* public async Task<MovieDetail> getMovieDetails(int movieId)
        {
            MovieDetail movieDetailList = new MovieDetail();
            var movie = await _movieApi.FindByIdAsync(movieId);
            var runTime = movie.Item.Runtime.ToString();
            movieDetailList = new MovieDetail()
            {
                Title = movie.Item.Title,
                Overview = movie.Item.Overview,
                Year = movie.Item.ReleaseDate,
                Genre = movie.Item.Genres,
                ImageUrl = movie.Item.PosterPath,
                RunningTime = runTime
            };

            return movieDetailList;
        }*/

        public async Task<List<MovieDetail>> getListOfMovieDetails(List<Movie> movieList)
        {
            List<MovieDetail> movieDetailList = new List<MovieDetail>();
            foreach (Movie movie in movieList)
            {
                var movieDetail = await _movieApi.FindByIdAsync(movie.Id);
                var runTime = movieDetail.Item.Runtime.ToString();
                movieDetailList.Add(new MovieDetail()
                {
                    Title = movieDetail.Item.Title,
                    Overview = movieDetail.Item.Overview,
                    Year = movieDetail.Item.ReleaseDate,
                    Genre = movieDetail.Item.Genres,
                    ImageUrl = movieDetail.Item.PosterPath,
                    RunningTime = runTime
                });
            }
            return movieDetailList;
        }

    } 
}

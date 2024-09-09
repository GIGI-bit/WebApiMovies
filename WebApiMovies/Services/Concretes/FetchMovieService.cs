
using Newtonsoft.Json.Linq;
using RestSharp;
using WebApiMovies.Entites;
using WebApiMovies.Services.Abstracts;

namespace WebApiMovies.Services.Concretes
{
    public class FetchMovieService : BackgroundService
    {
        private readonly IMovieService movieService;

        public FetchMovieService(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                int asscciNumber = (new Random()).Next(65, 91);
                string selectedLetter = ((char)asscciNumber).ToString();
                var response =await GetDataFromUrlAsync( selectedLetter);
                var list = ParseJsonToMovie(response, selectedLetter);
                foreach (var item in list)
                {
                    if(list.FirstOrDefault(i=> i.ResponseId==item.ResponseId) == null)
                    {
                        await movieService.Add(item);
                    }
                }

                await Task.Delay(TimeSpan.FromMinutes(15), stoppingToken);
            }
        }

        public async Task<string> GetDataFromUrlAsync(string selectedLetter)
        {
            var options = new RestClientOptions("https://api.themoviedb.org/3/search/movie");
            var client = new RestClient(options);
            var request = new RestRequest("");
            request.AddHeader("accept", "application/json");
            request.AddHeader("Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI1MmUwOTIzNzI1OGI2ODNjZDU0MjA0OTM3ODRlMzk1ZSIsIm5iZiI6MTcyNTg5NzM5Ni45NjMxMTMsInN1YiI6IjY2OTAwZTliZTZkYjllY2U5M2ZmNTZmZiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.ftFWk9D5hg-KfeBY1eAmRMva3PTQcSAejoam2Zcch4E");

            request.AddQueryParameter("query", selectedLetter);
            var response = await client.GetAsync(request);
            return response.Content;
        }

        public List<Movie> ParseJsonToMovie(string response,string selectedLetter)
        {
            JObject jsonObject = JObject.Parse(response);
            JArray jArray = (JArray)jsonObject["results"];
            var movieList = new List<Movie>();
            foreach (var item in jArray)
            {
                if (item["title"].ToString().StartsWith(selectedLetter))
                {
                    var movie = new Movie();
                    movie.ResponseId = Int32.Parse(item["id"].ToString());
                    movie.ImgURL = item["poster_path"].ToString();
                    movie.Title = item["title"].ToString();
                    movie.Description = item["overview"].ToString();
                    movieList.Add(movie);
                }
            }
            return movieList;

        }

    }
}

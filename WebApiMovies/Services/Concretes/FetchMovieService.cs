
namespace WebApiMovies.Services.Concretes
{
    public class FetchMovieService : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;

        public FetchMovieService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}

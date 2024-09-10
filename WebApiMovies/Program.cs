using Microsoft.EntityFrameworkCore;
using WebApiMovies.Data;
using WebApiMovies.DataAccess.Abstracts;
using WebApiMovies.DataAccess.Concretes;
using WebApiMovies.Repositories.Abstracts;
using WebApiMovies.Repositories.Concretes;
using WebApiMovies.Services.Abstracts;
using WebApiMovies.Services.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMovieDal, MovieDal>();
builder.Services.AddScoped<IMovieService, MovieService>();
//builder.Services.AddHttpClient<MovieService>();
builder.Services.AddHostedService<FetchMovieService>();

var con = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<MovieDBContext>(opt =>
{
    opt.UseSqlServer(con);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

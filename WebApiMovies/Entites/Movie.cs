﻿namespace WebApiMovies.Entites
{
    public class Movie
    {
        public int Id { get; set; }
        public int ResponseId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImgURL { get; set; }

    }
}

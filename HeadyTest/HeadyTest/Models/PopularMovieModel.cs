﻿using HeadyTest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeadyTest.Models
{

    public class PopularMovieModel
    {
        public double popularity { get; set; }
        public int vote_count { get; set; }
        public bool video { get; set; }
        public string poster_path { get; set; }
        public int id { get; set; }
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public List<int> genre_ids { get; set; }
        public string title { get; set; }
        public double vote_average { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public string popularityTwoDecimal
        {
            get => popularity.ToString("0.##");
        }
        public string Image
        {
            get => ApiServices.BaseImageAddress + poster_path;
        }

    }

       
    
}

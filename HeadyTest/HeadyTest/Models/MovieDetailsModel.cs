using HeadyTest.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeadyTest.Models
{
    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }

    public class ProductionCompany
    {
        public int id { get; set; }
        public string logo_path { get; set; }
        public string name { get; set; }
        public string origin_country { get; set; }
    }

    public class ProductionCountry
    {
        public string iso_3166_1 { get; set; }
        public string name { get; set; }
    }

    public class SpokenLanguage
    {
        public string iso_639_1 { get; set; }
        public string name { get; set; }
    }

    public class MovieDetails
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public string Image
        {
            get => ApiServices.BaseImageAddress + backdrop_path;
        }
        public string ReleaseDete
        {
            get
            {
                var date = Convert.ToDateTime(release_date);
                return date.ToString("MMMM dd yyyy");
            }
        }
        public object belongs_to_collection { get; set; }
        public int? budget { get; set; }
        public List<Genre> genres { get; set; }
        public string gener
        {
            get
            {
                string value = "";
                genres.ForEach(val =>
                {
                    value += val.name + " | ";
                });
                return value?.Remove(value.LastIndexOf('|'));
            }
        }
        public string homepage { get; set; }
        public int? id { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public double? popularity { get; set; }
        public string poster_path { get; set; }
        public List<ProductionCompany> production_companies { get; set; }
        public List<ProductionCountry> production_countries { get; set; }
        public string release_date { get; set; }
        public int? revenue { get; set; }
        public int? runtime { get; set; }

        public string TotalTime
        {
            get
            {
               TimeSpan ts = TimeSpan.FromMinutes(Convert.ToInt32(runtime));
                return string.Format("{0}h {1}m", ts.Hours, ts.Minutes);
            }
        }

        public List<SpokenLanguage> spoken_languages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public bool? video { get; set; }
        public double? vote_average { get; set; }
        public int? vote_count { get; set; }
    }
}

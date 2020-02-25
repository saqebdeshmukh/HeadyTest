using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HeadyTest.Models;
using System.Collections.ObjectModel;
using Acr.UserDialogs;

namespace HeadyTest.Services
{
    public class ApiServices
    {
        private static ApiServices _Instance;

        internal static ApiServices Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new ApiServices();

                return _Instance;
            }
        }
        public static string BaseImageAddress { get => "https://image.tmdb.org/t/p/w500"; }
        string BaseAddress { get => "https://api.themoviedb.org/3/"; }
        string APIKey { get => "77524ffe450a1f8620f1c41a95a668c4"; }
        public string Language = "en-US";
        HttpClient client;

        public ApiServices()
        {
            client = new HttpClient();
        }

        public async Task<Response<ObservableCollection<MovieModel>>> GetPopularMovies(int Page, bool IsSelectdPopular)
        {
            Response< ObservableCollection <MovieModel> > PopularMovies = new Response<ObservableCollection<MovieModel>>();
            HttpResponseMessage response = null;
            try
            {
                if(IsSelectdPopular)
                    response = await client.GetAsync(BaseAddress + "movie/popular?api_key=" + APIKey+"&language="+Language+"&page="+Page);
                else
                    response = await client.GetAsync(BaseAddress + "movie/top_rated?api_key=" + APIKey + "&language=" + Language + "&page=" + Page);

                //if (response.IsSuccessStatusCode)
                //{
                var x = await response.Content.ReadAsStringAsync();
                    PopularMovies = JsonConvert.DeserializeObject<Response<ObservableCollection<MovieModel>>>(x);
                //}
                //else
                //{

                //}
            }
            catch (Exception)
            {
                PopularMovies.success = false;
                PopularMovies.status_message = "Sorry!!! Something went wrong please check after some time or check your internet connectivity and try agian.";
            }

            return PopularMovies;

        }


        public async Task<Response<ObservableCollection<MovieModel>>> GetSearchMovies(int Page, string SearchString)
        {
            UserDialogs.Instance.ShowLoading();
            Response<ObservableCollection<MovieModel>> SearchMovies = new Response<ObservableCollection<MovieModel>>();
            HttpResponseMessage response = null;
            try
            {
                response = await client.GetAsync(BaseAddress + "search/movie/?api_key=" + APIKey + "&query="+ SearchString.ToUpper() + "&language=" + Language + "&page=" + Page+ "&include_adult=false");
                var x = await response.Content.ReadAsStringAsync();
                SearchMovies = JsonConvert.DeserializeObject<Response<ObservableCollection<MovieModel>>>(x);
            }
            catch (Exception)
            {
                SearchMovies.success = false;
                SearchMovies.status_message = "Sorry!!! Something went wrong please check after some time or check your internet connectivity and try agian.";
            }
            UserDialogs.Instance.HideLoading();
            return SearchMovies;

        }

        public async Task<MovieDetails> GetMovieDetails(int Id)
        {
            MovieDetails PopularMovies = new MovieDetails();
            HttpResponseMessage response = null;
            try
            {
                response = await client.GetAsync(BaseAddress+ "movie/" + Id+"?api_key=" + APIKey + "&language=" + Language);
                var x = await response.Content.ReadAsStringAsync();
                PopularMovies = JsonConvert.DeserializeObject<MovieDetails>(x);
            }
            catch (Exception)
            {
                //PopularMovies.success = false;
                //PopularMovies.status_message = "Sorry!!! Something went wrong please check after some time or check your internet connectivity and try agian.";
            }

            return PopularMovies;

        }
    }

    
}

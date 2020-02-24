using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HeadyTest.Models;
using System.Collections.ObjectModel;

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
        string BaseAddress { get => "https://api.themoviedb.org/3/movie/"; }
        string APIKey { get => "77524ffe450a1f8620f1c41a95a668c4"; }
        public string Language = "en-US";
        HttpClient client;

        public ApiServices()
        {
            client = new HttpClient();
        }

        public async Task<Response<ObservableCollection<PopularMovieModel>>> GetPopularMovies(int Page)
        {
            Response< ObservableCollection < PopularMovieModel> > PopularMovies = new Response<ObservableCollection<PopularMovieModel>>();
            HttpResponseMessage response = null;
            try
            {
                response = await client.GetAsync(BaseAddress + "popular?api_key="+APIKey+"&language="+Language+"&page="+Page);
                //if (response.IsSuccessStatusCode)
                //{
                    var x = await response.Content.ReadAsStringAsync();
                    PopularMovies = JsonConvert.DeserializeObject<Response<ObservableCollection<PopularMovieModel>>>(x);
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

        public async Task<Response<ObservableCollection<PopularMovieModel>>> GetMovieDetails(int Id)
        {
            Response<ObservableCollection<PopularMovieModel>> PopularMovies = new Response<ObservableCollection<PopularMovieModel>>();
            HttpResponseMessage response = null;
            try
            {
                response = await client.GetAsync(BaseAddress + "454626?api_key=" + APIKey + "&language=" + Language);
                //if (response.IsSuccessStatusCode)
                //{
                var x = await response.Content.ReadAsStringAsync();
                PopularMovies = JsonConvert.DeserializeObject<Response<ObservableCollection<PopularMovieModel>>>(x);
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
    }

    
}

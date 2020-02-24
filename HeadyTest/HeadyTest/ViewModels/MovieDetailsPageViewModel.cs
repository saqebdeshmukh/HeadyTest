using HeadyTest.Models;
using HeadyTest.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeadyTest.ViewModels
{
	public class MovieDetailsPageViewModel : ViewModelBase
	{
        private MovieDetails movieDetails;
        public MovieDetails MovieDetail
        {
            get => movieDetails;
            set => SetProperty(ref movieDetails, value);
        }
        public MovieDetailsPageViewModel(INavigationService navigationService):base(navigationService)
        {

        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if (parameters.ContainsKey("Id"))
            {
                var Resp = await ApiServices.Instance.GetMovieDetails(parameters.GetValue<int>("Id"));
                MovieDetail = Resp;

                //if (Resp.results != null)
                //{
                //}
                //else if (!string.IsNullOrEmpty(Resp.status_message))
                //{

                //}
            }
        }
    }
}

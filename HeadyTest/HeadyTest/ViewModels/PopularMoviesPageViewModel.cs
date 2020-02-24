using HeadyTest.Helper;
using HeadyTest.Models;
using HeadyTest.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace HeadyTest.ViewModels
{
	public class PopularMoviesPageViewModel : ViewModelBase
	{

        private ObservableRangeCollection<PopularMovieModel> _PopularMovies;
        public ObservableRangeCollection<PopularMovieModel> PopularMovies
        {
            get { return _PopularMovies; }
            set { SetProperty(ref _PopularMovies, value); }
        }
        int Page { get; set; }
        public DelegateCommand LoadMoreDataCommand { get; set; }
        public DelegateCommand<PopularMovieModel> MovieDetailCommand { get; set; }

        public PopularMoviesPageViewModel(INavigationService navigationService) :base(navigationService)
        {
            Page = 1;
            MessagingCenter.Subscribe<string>("", "OnAppearing", val =>
            {
                OnAppearing();
            });
            MovieDetailCommand = new DelegateCommand<PopularMovieModel>()
            LoadMoreDataCommand = new DelegateCommand(LoadData);
        }

        public async override void OnAppearing()
        {
            base.OnAppearing();
            if (PopularMovies == null)
            {
                PopularMovies = new ObservableRangeCollection<PopularMovieModel>();
                LoadData();
            }
        }

        async void LoadData()
        {
            var Resp = await ApiServices.Instance.GetPopularMovies(Page);

            if (Resp.results != null)
            {
                Page++;
                
                    PopularMovies.AddRange(Resp.results);
            }
            else if (!string.IsNullOrEmpty(Resp.status_message))
            {
                
            }
        }
    }
}

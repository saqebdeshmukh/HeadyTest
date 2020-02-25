using Acr.UserDialogs;
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

        private ObservableRangeCollection<MovieModel> _PopularMovies;
        public ObservableRangeCollection<MovieModel> PopularMovies
        {
            get { return _PopularMovies; }
            set { SetProperty(ref _PopularMovies, value); }
        }
        int Page { get; set; }
        public DelegateCommand LoadMoreDataCommand { get; set; }
        public DelegateCommand AlertBoxCommand { get; set; }
        public DelegateCommand<MovieModel> MovieDetailCommand { get; set; }

        string SelectLbl = "✔";
        string PopularLbl = "✔ Most Popular";
        string HighestRate = "  Highest Rated";
        string SelectedSortLbl = "Most Popular";


        public PopularMoviesPageViewModel(INavigationService navigationService) :base(navigationService)
        {
            Page = 1;

            AlertBoxCommand = new DelegateCommand(async () =>
            {
                if(SelectedSortLbl == "Most Popular")
                {
                    PopularLbl = "✔ Most Popular";
                    HighestRate = "  Highest Rated";
                }
                else
                {
                    PopularLbl =  "   Most Popular";
                    HighestRate = "✔ Highest Rated";
                }
                var ans = await UserDialogs.Instance.ActionSheetAsync("Filter", "Cancel", null, null, PopularLbl, HighestRate);
                if(ans != "Cancel")
                {
                    SelectedSortLbl = ans.Replace(SelectLbl,"").Trim();
                    Page = 1;
                    PopularMovies.Clear();
                    LoadData();
                }
            });

            MessagingCenter.Subscribe<string>("", "OnAppearing", val =>
            {
                OnAppearing();
            });
            MovieDetailCommand = new DelegateCommand<MovieModel>((val) =>
            {
                var param = new NavigationParameters();
                param.Add("Id", val.id);
            NavigationService.NavigateAsync("MovieDetailsPage", param, useModalNavigation:true);
            });
            LoadMoreDataCommand = new DelegateCommand(LoadData);
        }

        public async override void OnAppearing()
        {
            base.OnAppearing();
            if (PopularMovies == null)
            {
                PopularMovies = new ObservableRangeCollection<MovieModel>();
                LoadData();
            }
        }

        async void LoadData()
        {
            var Resp = await ApiServices.Instance.GetPopularMovies(Page, SelectedSortLbl == "Most Popular");

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

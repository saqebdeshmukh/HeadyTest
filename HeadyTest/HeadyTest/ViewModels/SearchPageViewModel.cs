using HeadyTest.Helper;
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
	public class SearchPageViewModel : ViewModelBase
	{
        
            private string _SearchText;
        public string SearchText
        {
            get { return _SearchText; }
            set { SetProperty(ref _SearchText, value); }
        }
        private ObservableRangeCollection<MovieModel> _Movies;
        public ObservableRangeCollection<MovieModel> Movies
        {
            get { return _Movies; }
            set { SetProperty(ref _Movies, value); }
        }
        int Page { get; set; }
        public DelegateCommand LoadMoreDataCommand { get; set; }
        public DelegateCommand<MovieModel> MovieDetailCommand { get; set; }
        public DelegateCommand SearchMoviesCommand { get; set; }
        public SearchPageViewModel(INavigationService navigationService):base(navigationService)
        {
            Movies = new ObservableRangeCollection<MovieModel>();
            MovieDetailCommand = new DelegateCommand<MovieModel>((val) =>
            {
                var param = new NavigationParameters();
                param.Add("Id", val.id);
                NavigationService.NavigateAsync("MovieDetailsPage", param, useModalNavigation: true);
            });
            LoadMoreDataCommand = new DelegateCommand(LoadData);
            SearchMoviesCommand = new DelegateCommand(async () =>
            {
                Page = 1;
                Movies.Clear();
                LoadData();
            });
        }
        //public async override void OnAppearing()
        //{
        //    base.OnAppearing();
        //    if (Movies == null)
        //    {
        //        Movies = new ObservableRangeCollection<MovieModel>();
        //        LoadData();
        //    }
        //}

        async void LoadData()
        {
            if (!string.IsNullOrEmpty(SearchText))
            {
                var Resp = await ApiServices.Instance.GetSearchMovies(Page, SearchText);

                if (Resp.results != null)
                {
                    Page++;

                   Movies.AddRange(Resp.results);
                }
                else if (!string.IsNullOrEmpty(Resp.status_message))
                {
                    
                }
            }
        }
    }
}

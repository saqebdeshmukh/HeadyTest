﻿using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeadyTest.ViewModels
{
	public class PopularMoviesPageViewModel : ViewModelBase
	{
        public PopularMoviesPageViewModel(INavigationService navigationService) :base(navigationService)
        {

        }
	}
}
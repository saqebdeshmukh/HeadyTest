using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HeadyTest.Views
{
    public partial class MainPage : Shell
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Shell_Appearing(object sender, EventArgs e)
        {
            MessagingCenter.Send("", "OnAppearing");
        }
    }
}
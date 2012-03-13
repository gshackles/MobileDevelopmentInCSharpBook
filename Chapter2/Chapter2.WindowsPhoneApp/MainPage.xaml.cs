using System;
using System.Net;
using System.Windows;
using Microsoft.Phone.Controls;

namespace Chapter2.WindowsPhoneApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ButtonClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(
                new Uri("/SecondPage.xaml?text=" +
                        HttpUtility.UrlEncode(DateTime.Now.ToLongTimeString()),
                        UriKind.Relative));
        }
    }

}
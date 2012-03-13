using System.Windows;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using SharedLibrary.Chapter4;

namespace Chapter4.WindowsPhoneApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            var client = new TwitterClient();

            client.GetTweetsForUser("OReillyMedia", tweets =>
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    DataContext = tweets;
                    Loading.Visibility = Visibility.Collapsed;
                });
            });

            client.MentionReceived += delegate(object sender, MentionEventArgs args)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    MessageBox.Show(args.Tweet.Text, "Mention Received",
                                    MessageBoxButton.OK);
                });
            };
        }

        private void TweetSelected(object sender, SelectionChangedEventArgs e)
        {
            var tweet = (Tweet)e.AddedItems[0];

            MessageBox.Show(tweet.Text, "Full Tweet", MessageBoxButton.OK);
        }
    }
}
using Microsoft.Phone.Controls;

namespace Chapter2.WindowsPhoneApp
{
    public partial class SecondPage : PhoneApplicationPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            TextReceived.Text = NavigationContext.QueryString["text"];
        }
    }
}
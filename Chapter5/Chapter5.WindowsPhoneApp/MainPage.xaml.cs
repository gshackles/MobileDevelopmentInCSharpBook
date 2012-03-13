using System;
using System.Net;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using SharedLibrary.Chapter5;

namespace Chapter5.WindowsPhoneApp
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

            DataContext = null;
            DataContext = App.NoteRepository.GetAllNotes();
        }

        private void NoteSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0)
                return;

            var note = (Note)e.AddedItems[0];

            NavigationService.Navigate(
                new Uri(
                    string.Format("/ViewNote.xaml?Id={0}&Title={1}&Content={2}",
                                  HttpUtility.UrlEncode(note.Id.ToString()),
                                  HttpUtility.UrlEncode(note.Title),
                                  HttpUtility.UrlEncode(note.Contents)),
                    UriKind.Relative));
        }

        private void AddNote(object sender, EventArgs e)
        {
            NavigationService.Navigate(
                new Uri("/AddNote.xaml", UriKind.Relative));
        }
    }
}
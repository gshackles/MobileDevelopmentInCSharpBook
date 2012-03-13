using System.Windows;
using Microsoft.Phone.Controls;

namespace Chapter5.WindowsPhoneApp
{
    public partial class AddNote : PhoneApplicationPage
    {
        public AddNote()
        {
            InitializeComponent();
        }

        private void SaveNote(object sender, RoutedEventArgs e)
        {
            App.NoteRepository.Add(Title.Text, Content.Text);

            NavigationService.GoBack();
        }
    }
}
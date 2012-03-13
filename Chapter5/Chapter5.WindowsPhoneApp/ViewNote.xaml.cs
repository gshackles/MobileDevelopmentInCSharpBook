using System;
using Microsoft.Phone.Controls;

namespace Chapter5.WindowsPhoneApp
{
    public partial class ViewNote : PhoneApplicationPage
    {
        private int _noteId;

        public ViewNote()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            PageTitle.Text = NavigationContext.QueryString["Title"];
            Content.Text = NavigationContext.QueryString["Content"];

            _noteId = int.Parse(NavigationContext.QueryString["Id"]);
        }

        private void DeleteNote(object sender, EventArgs e)
        {
            App.NoteRepository.Delete(_noteId);

            NavigationService.GoBack();
        }
    }
}
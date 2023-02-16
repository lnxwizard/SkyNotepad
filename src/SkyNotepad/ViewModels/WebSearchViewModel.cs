// Librarys
using System.Windows.Input;

// Project Librarys
using SkyNotepad.Helpers;

namespace SkyNotepad.ViewModels
{
    public class WebSearchViewModel
    {
        // Commands
        public ICommand SearchMSBingCommand { get; }
        public ICommand SearchGoogleCommand { get; }

        public WebSearchViewModel()
        {
            SearchMSBingCommand = new RelayCommand(SearchMSBing);
            SearchGoogleCommand = new RelayCommand(SearchGoogle);
        }

        private void SearchMSBing()
        {

        }

        private void SearchGoogle()
        {

        }
    }
}
// Librarys
using System;
using System.Windows.Input;
using Windows.System;

// Project Folders
using SkyNotepad.Models;
using SkyNotepad.Helpers;

namespace SkyNotepad.ViewModels
{
    public class WebSearchViewModel
    {
        // Document Model
        public DocumentModel Document { get; set; }

        // Commands
        public ICommand SearchWithMicrosoftBingCommand { get; set; }
        public ICommand SearchWithGoogleCommand { get; set; }
        public ICommand SearchWithDuckDuckGoCommand { get; set; }
        public ICommand SearchWithYandexCommand { get; set; }
        public ICommand SearchWithYahooCommand { get; set; }

        /// <summary>
        /// Loads commands
        /// </summary>
        /// <param name="_document"></param>
        public WebSearchViewModel(DocumentModel _document)
        {
            Document = _document;
            SearchWithMicrosoftBingCommand = new RelayCommand(MicrosoftBingSearch);
            SearchWithGoogleCommand = new RelayCommand(GoogleSearch);
            SearchWithDuckDuckGoCommand = new RelayCommand(DuckDuckSearch);
            SearchWithYandexCommand = new RelayCommand(YandexSearch);
            SearchWithYahooCommand = new RelayCommand(YahooSearch);
        }

        /// <summary>
        /// Search selected text in Microsoft Bing
        /// </summary>
        private async void MicrosoftBingSearch()
        {
            string searchString = Document.SelectedText;
            if (searchString == string.Empty)
            {
                Uri defaultUri = new Uri("https://bing.com/");
            }
            else
            {
                Uri searchUri = new Uri("https://bing.com/search?q=" + searchString);
                await Launcher.LaunchUriAsync(searchUri);
            }
        }

        /// <summary>
        /// Search selected text in Google
        /// </summary>
        private async void GoogleSearch()
        {
            string searchString = Document.SelectedText;
            if (searchString == string.Empty)
            {
                Uri defaultUri = new Uri("https://google.com/");
            }
            else
            {
                Uri searchUri = new Uri("https://google.com/search?q=" + searchString);
                await Launcher.LaunchUriAsync(searchUri);
            }
        }

        /// <summary>
        /// Search selected text in DuckDuckGo
        /// </summary>
        private async void DuckDuckSearch()
        {
            string searchString = Document.SelectedText;
            if (searchString == string.Empty)
            {
                Uri defaultUri = new Uri("https://duckduckgo.com/");
            }
            else
            {
                Uri searchUri = new Uri("https://duckduckgo.com/" + searchString);
                await Launcher.LaunchUriAsync(searchUri);
            }
        }

        /// <summary>
        /// Search selected text in Yandex
        /// </summary>
        private async void YandexSearch()
        {
            string searchString = Document.SelectedText;
            if (searchString == string.Empty)
            {
                Uri defaultUri = new Uri("https://yandex.com/");
            }
            else
            {
                Uri searchUri = new Uri("https://yandex.com/search/?text=" + searchString);
                await Launcher.LaunchUriAsync(searchUri);
            }
        }

        /// <summary>
        /// Search selected text in Yahoo
        /// </summary>
        private async void YahooSearch()
        {
            string searchString = Document.SelectedText;
            if (searchString == string.Empty)
            {
                Uri defaultUri = new Uri("https://yahoo.com/");
            }
            else
            {
                Uri searchUri = new Uri("https://search.yahoo.com/search?p=" + searchString);
                await Launcher.LaunchUriAsync(searchUri);
            }
        }
    }
}
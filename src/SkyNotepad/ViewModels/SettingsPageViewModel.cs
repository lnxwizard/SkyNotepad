// Librarys
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Windows.Input;

// Project Folders
using SkyNotepad.Helpers;

namespace SkyNotepad.ViewModels
{
    public class SettingsPageViewModel
    {
        // Commands
        public ICommand GoBackCommand { get; }

        /// <summary>
        /// Loads Commands
        /// </summary>
        public SettingsPageViewModel()
        {
            GoBackCommand = new RelayCommand(GoBack);
        }

        /// <summary>
        /// Go back from settings menu to main page
        /// </summary>
        private void GoBack()
        {
            if (Window.Current.Content is Frame rootFrame && rootFrame.CanGoBack)
            {
                rootFrame.GoBack();
            }
            else
            {
                ContentDialog ErrorCannotGoBackDialog = new ContentDialog()
                {
                    Title = "Error",
                    Content = "Cannot Go Back! Try Again",
                    CloseButtonText = "OK"
                };

                _ = ErrorCannotGoBackDialog.ShowAsync();
            }
        }
    }
}
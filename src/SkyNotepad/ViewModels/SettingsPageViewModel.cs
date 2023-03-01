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

        // Constructor Method
        public SettingsPageViewModel()
        {
            GoBackCommand = new RelayCommand(GoBack);
        }

        // Go Back from Settings Page Command
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
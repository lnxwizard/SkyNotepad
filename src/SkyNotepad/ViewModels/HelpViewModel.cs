// Librarys
using System.Windows.Input;

// From Project
using SkyNotepad.Helpers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using SkyNotepad.Views.Settings;

namespace SkyNotepad.ViewModels
{
    public class HelpViewModel
    {
        // Help Menu Items
        public ICommand SettingsCommand { get; }

        // Main Method
        public HelpViewModel()
        {
            SettingsCommand = new RelayCommand(ViewSettings);
        }

        /// <summary>
        /// Opens Settings menu
        /// </summary>
        private void ViewSettings()
        {
            if (Window.Current.Content is Frame rootFrame)
            {
                rootFrame.Navigate(typeof(SettingsPage));
            }
        }
    }
}
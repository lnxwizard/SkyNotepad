// Librarys
using System;
using System.Windows.Input;
using Windows.System;

// From Project
using SkyNotepad.Helpers;
using SkyNotepad.Views.Dialogs;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using SkyNotepad.Views.Settings;

namespace SkyNotepad.ViewModels
{
    public class HelpViewModel
    {
        // Help Menu Items
        public ICommand RepositoryCommand { get; }
        public ICommand CreateIssueCommand { get; }
        public ICommand ViewLicenseCommand { get; }
        public ICommand SettingsCommand { get; }

        // Main Method
        public HelpViewModel()
        {
            SettingsCommand = new RelayCommand(ViewSettings);
            RepositoryCommand = new RelayCommand(OpenRepository);
            CreateIssueCommand = new RelayCommand(CreateIssue);
            ViewLicenseCommand = new RelayCommand(ViewLicense);
        }

        // Repository
        private async void OpenRepository()
        {
            Uri repoUri = new Uri("https://github.com/AlperAkca79/SkyNotepad");
            await Launcher.LaunchUriAsync(repoUri);
        }

        // Create Issue on GitHub
        private async void CreateIssue()
        {
            Uri createIssueUri = new Uri("https://github.com/AlperAkca79/SkyNotepad/issues/new");
            await Launcher.LaunchUriAsync(createIssueUri);
        }

        // View License
        private async void ViewLicense()
        {
            Uri viewLicenseUri = new Uri("https://github.com/AlperAkca79/SkyNotepad/blob/master/LICENSE");
            await Launcher.LaunchUriAsync(viewLicenseUri);
        }

        // Settings
        private void ViewSettings()
        {
            if (Window.Current.Content is Frame rootFrame)
            {
                rootFrame.Navigate(typeof(SettingsPage));
            }
        }
    }
}
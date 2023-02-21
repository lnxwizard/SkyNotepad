// Librarys
using System.Windows.Input;
using Windows.UI.ViewManagement;

// From Project
using SkyNotepad.Helpers;

namespace SkyNotepad.ViewModels
{
    public class ScreenViewModel
    {
        // Application View
        private ApplicationView AppView = ApplicationView.GetForCurrentView();

        // Menu Item Commands
        public ICommand FullScreenModeCommand { get; }

        // Main Method
        public ScreenViewModel()
        {
            FullScreenModeCommand = new RelayCommand(ToggleFullScreen);
        }

        // Toggle Full Screen Mode
        private void ToggleFullScreen()
        {
            bool isInFullScreenMode = AppView.IsFullScreenMode;

            if (isInFullScreenMode)
            {
                AppView.ExitFullScreenMode();
            }
            else
            {
                AppView.TryEnterFullScreenMode();
            }
        }
    }
}
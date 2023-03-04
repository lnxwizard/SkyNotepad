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

        /// <summary>
        /// Loads commands
        /// </summary>
        public ScreenViewModel()
        {
            FullScreenModeCommand = new RelayCommand(ToggleFullScreen);
        }

        /// <summary>
        /// Toggle Full Screen Mode on or off
        /// </summary>
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
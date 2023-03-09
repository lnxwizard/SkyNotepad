// Librarys
using System;
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
        public ICommand CompactOverlayCommand { get; }

        /// <summary>
        /// Loads commands
        /// </summary>
        public ScreenViewModel()
        {
            FullScreenModeCommand = new RelayCommand(ToggleFullScreen);
            CompactOverlayCommand = new RelayCommand(ToggleCompactOverlay);
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

        /// <summary>
        /// Toggle compact overlay mode on or off
        /// </summary>
        private async void ToggleCompactOverlay()
        {
            if (ApplicationView.GetForCurrentView().ViewMode == ApplicationViewMode.CompactOverlay)
            {
                await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.Default);
            }
            else
            {
                await ApplicationView.GetForCurrentView().TryEnterViewModeAsync(ApplicationViewMode.CompactOverlay);
            }
        }
    }
}
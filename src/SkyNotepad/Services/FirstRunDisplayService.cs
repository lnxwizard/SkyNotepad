// Imported Librarys
using System;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Microsoft.Toolkit.Uwp.Helpers;

// Project Folders
using SkyNotepad.Views.Dialogs;

namespace SkyNotepad.Services
{
    public static class FirstRunDisplayService
    {
        private static bool IsShown = false;

        internal static async Task ShowIfAppropriateAsync()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal, () =>
                {
                    if (SystemInformation.Instance.IsFirstRun && !IsShown)
                    {
                        IsShown = true;
                        Frame frame = new Frame();
                        frame.Navigate(typeof(FirstRunDialog));
                    }
                }
            );
        }
    }
}
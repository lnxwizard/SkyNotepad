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
                CoreDispatcherPriority.Normal, async () =>
                {
                    if (SystemInformation.Instance.IsFirstRun && !IsShown)
                    {
                        IsShown = true;
                        ContentDialog firstRunDialog = new ContentDialog()
                        {
                            Title = "Welcome to SkyNotepad",
                            Content = "This is SkyNotepad. You can open/edit text documents and markdown source files.",
                            CloseButtonText = "Close"
                        };
                        await firstRunDialog.ShowAsync();
                    }
                }
            );
        }
    }
}
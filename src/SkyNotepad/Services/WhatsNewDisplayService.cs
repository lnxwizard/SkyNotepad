// Imported Librarys
using System;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Core;
using Microsoft.Toolkit.Uwp.Helpers;

// Projects Folders
using SkyNotepad.Views.Dialogs;

namespace SkyNotepad.Services
{
    public static class WhatsNewDisplayService
    {
        private static bool shown = false;

        internal static async Task ShowIfAppropriateAsync()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal, async () =>
                {
                    if (SystemInformation.Instance.IsAppUpdated && !shown)
                    {
                        shown = true;
                        ContentDialog whatsNewDialog = new ContentDialog()
                        {
                            Title = "What's New In This Version?",
                            Content = new WhatsNewDialog(),
                            CloseButtonText = "Close"
                        };
                        await whatsNewDialog.ShowAsync();
                    }
                }
            );
        }
    }
}
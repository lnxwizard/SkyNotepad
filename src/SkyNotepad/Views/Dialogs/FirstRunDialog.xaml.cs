// Imported Librarys
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
using SkyNotepad.Views.Settings;
using System;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SkyNotepad.Views.Dialogs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FirstRunDialog : Page
    {
        public FirstRunDialog()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Hides default title bar and replaces with custom title bar 
        /// </summary>
        /// <param name="sender">Grid</param>
        /// <param name="e">Loaded</param>
        private void DragRegion_Loaded(object sender, RoutedEventArgs e)
        {
            // Hide default title bar.
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            // Set caption buttons background to transparent.
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;

            // Set XAML element as a drag region.
            Window.Current.SetTitleBar(DragRegion);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender">Button</param>
        /// <param name="e">Click</param>
        private void ButtonStartUsing_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ButtonWhatsNew_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog WhatsNewDialog = new ContentDialog()
            {
                Title = "What's New In This Version?",
                CloseButtonText = "Close"
            };
            WhatsNewDialog.Content = new WhatsNewDialog();
            await WhatsNewDialog.ShowAsync();
        }
    }
}
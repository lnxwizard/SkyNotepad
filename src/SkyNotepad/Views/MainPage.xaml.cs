// Librarys
using System;
using System.IO;
using Windows.Foundation;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.System;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.Activation;

// Project Folders
using SkyNotepad.ViewModels;
using SkyNotepad.Models;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SkyNotepad.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Changes application title bar buttons background/foreground colors when Main Page loadeds
        /// </summary>
        /// <param name="sender">Page</param>
        /// <param name="e"></param>
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationView appView = ApplicationView.GetForCurrentView();
            
            // Default
            appView.TitleBar.ButtonForegroundColor = Colors.Black;
            
            // Hover
            appView.TitleBar.ButtonHoverForegroundColor = Colors.Black;
            appView.TitleBar.ButtonHoverBackgroundColor = Colors.LightGray;

            // Inactive
            appView.TitleBar.ButtonInactiveBackgroundColor = Colors.White;
            appView.TitleBar.ButtonInactiveForegroundColor = Colors.Black;

            // Pressed
            appView.TitleBar.ButtonPressedBackgroundColor = Color.FromArgb(255, 225, 225, 225);
            appView.TitleBar.ButtonPressedForegroundColor = Colors.Black;
        }

        /// <summary>
        /// Hides default titlebar and replaces with custom titlebar
        /// </summary>
        /// <param name="sender">Grid</param>
        /// <param name="e"></param>
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
        /// Undo changes from textbox
        /// </summary>
        /// <param name="sender">Menu Flyout Item</param>
        /// <param name="e">Menu Flyout Item</param>
        private void MenuItemUndo_Click(object sender, RoutedEventArgs e)
        {
            if(TextBox.CanUndo == true)
            {
                TextBox.Undo();
            }
            else { }
        }

        /// <summary>
        /// Redo changes from textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Menu Flyout Item</param>
        private void MenuItemRedo_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox.CanRedo == true)
            {
                TextBox.Redo();
            }
            else { }
        }

        /// <summary>
        /// Cut selected text in textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Menu Flyout Item</param>
        private void MenuItemCut_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox.SelectedText))
            {
                
            }
            else
            {
                TextBox.CutSelectionToClipboard();
            }
        }

        /// <summary>
        /// Copy selected text in textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Menu Flyout Item</param>
        private void MenuItemCopy_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox.SelectedText))
            {

            }
            else
            {
                TextBox.CopySelectionToClipboard();
            }
        }

        /// <summary>
        /// Paste from clipboard to textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Menu Flyout Item</param>
        private void MenuItemPaste_Click(object sender, RoutedEventArgs e)
        {
            TextBox.PasteFromClipboard();
        }

        /// <summary>
        /// Select all text in textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Menu Flyout Item</param>
        private void MenuItemSelectAll_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox.Text))
            {

            }
            else
            {
                TextBox.SelectAll();
            }
        }

        /// <summary>
        /// Puts system time and date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Menu Flyout Item</param>
        private void MenuItemTimeDate_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            TextBox.SelectedText = dateTime.ToString();
        }

        /// <summary>
        /// Toggle Spell Checking feature on or off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Toggle Menu Flyout Item</param>
        private void MenuItemSpellCheck_Click(object sender, RoutedEventArgs e)
        {
            if (MenuItemSpellCheck.IsChecked == true)
            {
                TextBox.IsSpellCheckEnabled = true;
            }
            else 
            {
                TextBox.IsSpellCheckEnabled = false;
            }
        }

        /// <summary>
        /// Search selected text in Microsoft Bing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Menu Flyout Item</param>
        private async void MenuItemMicrosoftBing_Click(object sender, RoutedEventArgs e)
        {
            string searchString = TextBox.SelectedText;
            if (searchString == string.Empty)
            {
                Uri defaultUri = new Uri("https://bing.com/");
            }
            else
            {
                Uri searchUri = new Uri("https://bing.com/search?q=" + searchString);
                await Launcher.LaunchUriAsync(searchUri);
            }
        }

        /// <summary>
        /// Search selected text in Google
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Menu Flyout Item</param>
        private async void MenuItemGoogle_Click(object sender, RoutedEventArgs e)
        {
            string searchString = TextBox.SelectedText;
            if (searchString == string.Empty)
            {
                Uri defaultUri = new Uri("https://google.com/");
            }
            else
            {
                Uri searchUri = new Uri("https://google.com/search?q=" + searchString);
                await Launcher.LaunchUriAsync(searchUri);
            }
        }

        /// <summary>
        /// Search selected text in DuckDuckGo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Menu Flyout Item</param>
        private async void MenuItemDuckDuckGo_Click(object sender, RoutedEventArgs e)
        {
            string searchString = TextBox.SelectedText;
            if (searchString == string.Empty)
            {
                Uri defaultUri = new Uri("https://duckduckgo.com/");
            }
            else
            {
                Uri searchUri = new Uri("https://duckduckgo.com/" + searchString);
                await Launcher.LaunchUriAsync(searchUri);
            }
        }

        /// <summary>
        /// Search selected text in Yandex
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Menu Flyout Item</param>
        private async void MenuItemYandex_Click(object sender, RoutedEventArgs e)
        {
            string searchString = TextBox.SelectedText;
            if (searchString == string.Empty)
            {
                Uri defaultUri = new Uri("https://yandex.com/");
            }
            else
            {
                Uri searchUri = new Uri("https://yandex.com/search/?text=" + searchString);
                await Launcher.LaunchUriAsync(searchUri);
            }
        }

        /// <summary>
        /// Search selected text in Yahoo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Menu Flyout Item</param>
        private async void MenuItemYahoo_Click(object sender, RoutedEventArgs e)
        {
            string searchString = TextBox.SelectedText;
            if (searchString == string.Empty)
            {
                Uri defaultUri = new Uri("https://yahoo.com/");
            }
            else
            {
                Uri searchUri = new Uri("https://search.yahoo.com/search?p=" + searchString);
                await Launcher.LaunchUriAsync(searchUri);
            }
        }

        /// <summary>
        /// Toggle Compact Overlay mode on or off
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Menu Flyout Item</param>
        private async void MenuItemCompactOverlay_Click(object sender, RoutedEventArgs e)
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
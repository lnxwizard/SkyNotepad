// Librarys
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
using System.Collections.Generic;
using System.Linq;

// Project Folders
using SkyNotepad.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SkyNotepad.Views.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Hides default title bar and replaces with custom title bar
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
        /// Opens About Page when Settings Page loaded
        /// </summary>
        /// <param name="sender">Navigation View</param>
        /// <param name="e"></param>
        private void SettigsNavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(AboutPage));
        }

        /// <summary>
        /// Opens the menu item selected by the user
        /// </summary>
        /// <param name="sender">Navigation View</param>
        /// <param name="args"></param>
        private void SettigsNavigationView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected == false)
            {
                var selectedItem = (Microsoft.UI.Xaml.Controls.NavigationViewItem)args.SelectedItem;
                switch (selectedItem.Content.ToString())
                {
                    case "About":
                        ContentFrame.Navigate(typeof(AboutPage));
                        break;
                    case "Help":
                        ContentFrame.Navigate(typeof(HelpPage));
                        break;
                    case "What's New":
                        ContentFrame.Navigate(typeof(WhatIsNewPage));
                        break;
                }
            }
        }

        /// <summary>
        /// Handle text change and present suitable items
        /// </summary>
        /// <param name="sender">Navigation View</param>
        /// <param name="args"></param>
        private void AutoSuggest_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var suitableItems = new List<string>();
                var splitText = sender.Text.ToLower().Split(" ");
                foreach (var MenuItem in SettingContentsProvider.MenuContents)
                {
                    var found = splitText.All((key) =>
                    {
                        return MenuItem.ToLower().Contains(key);
                    });
                    if (found)
                    {
                        suitableItems.Add(MenuItem);
                    }
                }
                if (suitableItems.Count == 0)
                {
                    suitableItems.Add("No results found");
                }
                sender.ItemsSource = suitableItems;
            }
        }

        /// <summary>
        /// Handle user who selected an item, in our case just go to the selected item
        /// </summary>
        /// <param name="sender">Auto Suggest Box</param>
        /// <param name="args"></param>
        private void AutoSuggest_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            try
            {
                switch (args.SelectedItem.ToString())
                {
                    // In AboutPage.xaml
                    case "About":
                        ContentFrame.Navigate(typeof(AboutPage));
                        NavigationItemAbout.IsSelected = true;
                        break;
                    case "Dependencies and References":
                        ContentFrame.Navigate(typeof(AboutPage));
                        NavigationItemAbout.IsSelected = true;
                        break;
                    case "Developer":
                        ContentFrame.Navigate(typeof(AboutPage));
                        NavigationItemAbout.IsSelected = true;
                        break;
                    case "License":
                        ContentFrame.Navigate(typeof(AboutPage));
                        NavigationItemAbout.IsSelected = true;
                        break;
                    case "Last Updated":
                        ContentFrame.Navigate(typeof(AboutPage));
                        NavigationItemAbout.IsSelected = true;
                        break;
                    case "Version":
                        ContentFrame.Navigate(typeof(AboutPage));
                        NavigationItemAbout.IsSelected = true;
                        break;

                    // In HelpPage.xaml
                    case "Bug Report":
                        ContentFrame.Navigate(typeof(HelpPage));
                        NavigationItemHelp.IsSelected = true;
                        break;
                    case "Contributing":
                        ContentFrame.Navigate(typeof(HelpPage));
                        NavigationItemHelp.IsSelected = true;
                        break;
                    case "Discussion":
                        ContentFrame.Navigate(typeof(HelpPage));
                        NavigationItemHelp.IsSelected = true;
                        break;
                    case "Help":
                        ContentFrame.Navigate(typeof(HelpPage));
                        NavigationItemHelp.IsSelected = true;
                        break;
                    case "Other Links":
                        ContentFrame.Navigate(typeof(HelpPage));
                        NavigationItemHelp.IsSelected = true;
                        break;
                    case "Shortcuts":
                        ContentFrame.Navigate(typeof(HelpPage));
                        NavigationItemHelp.IsSelected = true;
                        break;

                    // In WhatsNewPage.xaml
                    case "What's New?":
                        ContentFrame.Navigate(typeof(WhatIsNewPage));
                        NavigationItemWhatsNew.IsSelected = true;
                        break;
                    case "Changelog":
                        ContentFrame.Navigate(typeof(WhatIsNewPage));
                        NavigationItemWhatsNew.IsSelected = true;
                        break;
                }
            }
            catch
            {
                ContentDialog CannotNavigateError = new ContentDialog()
                {
                    Title = "Error",
                    Content = "Cannot Navigate! Try Agin.",
                    CloseButtonText = "OK",
                    DefaultButton = ContentDialogButton.Close
                };
            }
            finally
            {
                AutoSuggest.Text = string.Empty;
            }
        }
    }
}
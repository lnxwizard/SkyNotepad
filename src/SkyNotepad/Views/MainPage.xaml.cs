// Librarys
using System;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.DataTransfer;

// From Project
using SkyNotepad.Views.Dialogs;
using SkyNotepad.ViewModels;
using SkyNotepad.Models;
using System.Collections.Generic;


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

        // Load Event
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        // Undo Command
        private void MenuItemUndo_Click(object sender, RoutedEventArgs e)
        {
            if(TextBox.CanUndo == true)
            {
                TextBox.Undo();
            }
            else { }
        }

        // Redo Command
        private void MenuItemRedo_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox.CanRedo == true)
            {
                TextBox.Redo();
            }
            else { }
        }

        // Cut Command
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

        // Copy Command
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

        // Paste Command
        private void MenuItemPaste_Click(object sender, RoutedEventArgs e)
        {
            TextBox.PasteFromClipboard();
        }

        // Select All Command
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

        // Time Date Command
        private void MenuItemTimeDate_Click(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            TextBox.SelectedText = dateTime.ToString();
        }

        // Spell Check Command
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

        // Search With Microsoft Bing
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

        // Search With Google
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

        // Search With DuckDuckGo
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

        // Search With Yandex
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
    }
}
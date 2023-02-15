// Librarys
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// From Project
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
    }
}
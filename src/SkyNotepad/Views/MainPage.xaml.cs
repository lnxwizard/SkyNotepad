using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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
    }
}

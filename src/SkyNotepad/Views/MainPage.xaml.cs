// Imported Librarys
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using SkyNotepad.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SkyNotepad.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /// <summary>
        /// Constructor for MainPage
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            ShareLoad();
            ApplicationSettings.GetSettings("SpellCheck");
        }

        /// <summary>
        /// Changes application title bar buttons background/foreground colors when Main Page loadeds
        /// </summary>
        /// <param name="sender">Page</param>
        /// <param name="e">Loaded</param>
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Application View
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
        /// Undo changes from textbox
        /// </summary>
        /// <param name="sender">Menu Flyout Item</param>
        /// <param name="e">Click</param>
        private void MenuItemUndo_Click(object sender, RoutedEventArgs e)
        {
            if(TextBox.CanUndo == true)
            {
                TextBox.Undo();
            }
        }

        /// <summary>
        /// Redo changes from textbox
        /// </summary>
        /// <param name="sender">Menu Flyout Item</param>
        /// <param name="e">Click</param>
        private void MenuItemRedo_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox.CanRedo == true)
            {
                TextBox.Redo();
            }
        }

        /// <summary>
        /// Cut selected text in textbox
        /// </summary>
        /// <param name="sender">Menu Flyout Item</param>
        /// <param name="e">Click</param>
        private void MenuItemCut_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox.SelectedText))
            {
                TextBox.CutSelectionToClipboard();
            }
        }

        /// <summary>
        /// Copy selected text in textbox
        /// </summary>
        /// <param name="sender">Menu Flyout Item</param>
        /// <param name="e">Click</param>
        private void MenuItemCopy_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox.SelectedText))
            {
                TextBox.CopySelectionToClipboard();
            }
        }

        /// <summary>
        /// Paste from clipboard to textbox
        /// </summary>
        /// <param name="sender">Menu Flyout Item</param>
        /// <param name="e">Click</param>
        private void MenuItemPaste_Click(object sender, RoutedEventArgs e)
        {
            if (TextBox.CanPasteClipboardContent == true)
            {
                TextBox.PasteFromClipboard();
            }
        }

        /// <summary>
        /// Select all text in textbox
        /// </summary>
        /// <param name="sender">Menu Flyout Item</param>
        /// <param name="e">Click</param>
        private void MenuItemSelectAll_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox.Text))
            {
                TextBox.SelectAll();
            }
        }

        /// <summary>
        /// Toggle Spell Checking feature on or off
        /// </summary>
        /// <param name="sender">Toggle Menu Flyout Item</param>
        /// <param name="e">Click</param>
        private void MenuItemSpellCheck_Click(object sender, RoutedEventArgs e)
        {
            ApplicationSettings.SaveSettings("SpellCheck", MenuItemSpellCheck.IsChecked);
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
        /// Toggle Markdown preview on or off
        /// </summary>
        /// <param name="sender">App Bar Button</param>
        /// <param name="e">Click</param>
        private void AppBarButtonMarkdownPreview_Click(object sender, RoutedEventArgs e)
        {
            if (MainSplitView.IsPaneOpen == true)
            {
                MainSplitView.IsPaneOpen = false;
                AppBarButtonMarkdownPreview.Icon = new SymbolIcon(Symbol.ClosePane);
            }
            else
            {
                MainSplitView.IsPaneOpen = true;
                AppBarButtonMarkdownPreview.Icon = new SymbolIcon(Symbol.OpenPane);
            }
        }

        /// <summary>
        /// Loads share service
        /// </summary>
        private void ShareLoad()
        {
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(this.DataRequested);
        }

        /// <summary>
        /// Data request for sharing service
        /// </summary>
        /// <param name="sender">Data Transfer Manager</param>
        /// <param name="e">Data Requested</param>
        private void DataRequested(DataTransferManager sender, DataRequestedEventArgs e)
        {
            DataRequest request = e.Request;
            request.Data.Properties.Title = "SkyNotepad Sharing Service";
            request.Data.Properties.Description = "Share your Document to selected people/E-Mail";
            request.Data.SetText(TextBox.Text.ToString());
        }

        /// <summary>
        /// Loads share service and shows share UI
        /// </summary>
        /// <param name="sender">App Bar Button</param>
        /// <param name="e">Click</param>
        private void AppBarButtonShare_Click(object sender, RoutedEventArgs e)
        {
            ShareLoad();
            DataTransferManager.ShowShareUI();
        }
    }
}
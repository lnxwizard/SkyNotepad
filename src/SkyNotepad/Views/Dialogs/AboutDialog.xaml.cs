// Librarys
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel;
using SkyNotepad.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SkyNotepad.Views.Dialogs
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AboutDialog : Page
    {
        public AboutDialog()
        {
            InitializeComponent();
        }

        private void AboutDialog_Loaded(object sender, RoutedEventArgs e)
        {
            // Application Version Info
            int AppVersionMajor = Package.Current.Id.Version.Major;
            int AppVersionMinor = Package.Current.Id.Version.Minor;
            int AppVersionRevision = Package.Current.Id.Version.Revision;
            int AppVersionBuild = Package.Current.Id.Version.Build;

            VersionInfo.Text = $"Version: Preview v{AppVersionMajor}.{AppVersionMinor}.{AppVersionRevision}.{AppVersionBuild}";

            // Application Author
            DeveloperInfo.Text = "Developer: AlperAkca79";

            // Insider Channel
            InsiderChannel.Text = "Insider Channel: Preview";
        }
    }
}
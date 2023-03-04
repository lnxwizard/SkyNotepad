// Librarys
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SkyNotepad.Views.Settings
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AboutPage : Page
    {
        public AboutPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Sets application version when about page loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Application Version Info
            int AppVersionMajor = Package.Current.Id.Version.Major;
            int AppVersionMinor = Package.Current.Id.Version.Minor;
            int AppVersionBuild = Package.Current.Id.Version.Build;
            int AppVersionRevision = Package.Current.Id.Version.Revision;

            TextBlockVersion.Text = $"Version: v{AppVersionMajor}.{AppVersionMinor}.{AppVersionBuild}.{AppVersionRevision}";
        }
    }
}
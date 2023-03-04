// Project Folders
using SkyNotepad.Models;

namespace SkyNotepad.ViewModels
{
    public class MainViewModel
    {
        // Model
        private DocumentModel Document;

        // View Model(s)
        public FileViewModel File { get; set; }
        public FormatViewModel Format { get; set; }
        public ScreenViewModel Screen { get; set; }
        public HelpViewModel Help { get; set; }
        public SettingsPageViewModel SettingsPage { get; set; }

        /// <summary>
        /// Loads View Models
        /// </summary>
        public MainViewModel()
        {
            Document = new DocumentModel();
            File = new FileViewModel(Document);
            Format = new FormatViewModel(Document);
            Screen = new ScreenViewModel();
            Help = new HelpViewModel();
            SettingsPage = new SettingsPageViewModel();
        }
    }
}
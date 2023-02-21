// Project Librarys
using SkyNotepad.Models;

namespace SkyNotepad.ViewModels
{
    public class MainViewModel
    {
        // Model
        public DocumentModel Document;

        // View Model(s)
        public FileViewModel File { get; set; }
        public FormatViewModel Format { get; set; }
        public WebSearchViewModel WebSearch { get; set; }
        public ScreenViewModel Screen { get; set; }
        public HelpViewModel Help { get; set; }

        // Main Method
        public MainViewModel()
        {
            Document = new DocumentModel();
            File = new FileViewModel(Document);
            Format = new FormatViewModel(Document);
            WebSearch = new WebSearchViewModel();
            Screen = new ScreenViewModel();
            Help = new HelpViewModel();
        }
    }
}
// Project Librarys
using SkyNotepad.Models;

namespace SkyNotepad.ViewModels
{
    public class MainViewModel
    {
        public DocumentModel Document;

        public FileViewModel File { get; set; }
        public FormatViewModel Format { get; set; }
        public WebSearchViewModel WebSearch { get; set; }
        public HelpViewModel Help { get; set; }

        public MainViewModel()
        {
            Document = new DocumentModel();
            File = new FileViewModel(Document);
            Format = new FormatViewModel(Document);
            WebSearch = new WebSearchViewModel();
            Help = new HelpViewModel();
        }
    }
}
using SkyNotepad.Models;

namespace SkyNotepad.ViewModels
{
    public class MainViewModel
    {
        private DocumentModel _document;

        public FileViewModel File { get; set; }
        public FormatViewModel Format { get; set; }

        public MainViewModel()
        {
            _document = new DocumentModel();
            File = new FileViewModel(_document);
            Format = new FormatViewModel(_document);
        }
    }
}
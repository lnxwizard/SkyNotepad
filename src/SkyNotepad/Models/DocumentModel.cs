// Project Folders
using SkyNotepad.Helpers;

namespace SkyNotepad.Models
{
    public class DocumentModel : ObservableObject
    {
        private string _text;
        public string Text
        {
            get { return _text; }
            set { OnPropertyChanged(ref _text, value); }

        }

        private string _selectedText;
        public string SelectedText
        {
            get { return _selectedText; }
            set { OnPropertyChanged(ref _selectedText, value); }
        }

        private string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set { OnPropertyChanged(ref _filePath, value); }

        }

        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set { OnPropertyChanged(ref _fileName, value); }
        }

        private string _fileType;
        public string FileType
        {
            get { return _fileType; }
            set { OnPropertyChanged(ref _fileType, value); }
        }

        private string _dateCreated;
        public string DateCreated
        {
            get { return _dateCreated; }
            set { OnPropertyChanged(ref _dateCreated, value); }
        }

        private string _appTitle;
        public string AppTitle
        {
            get { return _appTitle; }
            set { OnPropertyChanged(ref _appTitle, value); }
        }

        public bool isEmpty
        {
            get
            {
                if (string.IsNullOrEmpty(FileName) || string.IsNullOrEmpty(FilePath) || string.IsNullOrEmpty(AppTitle) || string.IsNullOrEmpty(SelectedText))
                    return true;

                return false;
            }
        }

        public bool IsSaved = false;

        public string FileToken { get; set; }
    }
}
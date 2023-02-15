// Librarys
using Windows.UI.Xaml;

// Project Librarys 
using SkyNotepad.Helpers;

namespace SkyNotepad.Models
{
    public class FormatModel : ObservableObject
    {
        // Text Wrapping
        private TextWrapping _wrap;
        public TextWrapping Wrap
        {
            get { return _wrap; }
            set
            {
                OnPropertyChanged(ref _wrap, value);
                isWrapped = value == TextWrapping.Wrap ? true : false;
            }
        }

        private bool _isWrapped;
        public bool isWrapped
        {
            get { return _isWrapped; }
            set { OnPropertyChanged(ref _isWrapped, value); }
        }
    }
}
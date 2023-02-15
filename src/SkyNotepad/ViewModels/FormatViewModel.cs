// Librarys
using Windows.UI.Xaml;
using Windows.UI.Text;
using System.Windows.Input;

// Project Librarys
using SkyNotepad.Helpers;
using SkyNotepad.Models;

namespace SkyNotepad.ViewModels
{
    public class FormatViewModel
    {
        // Format & Document Models
        public FormatModel Format { get; set; }
        public DocumentModel Document { get; set; }

        // Format Menu Items
        public ICommand WordWrap { get; set; }

        public FormatViewModel(DocumentModel document)
        {
            Document = document;
            Format = new FormatModel();
            WordWrap = new RelayCommand(Wrap);
        }

        // Word Wrap Command
        private void Wrap()
        {
            if (Format.Wrap == TextWrapping.Wrap)
                Format.Wrap = TextWrapping.NoWrap;

            else
                Format.Wrap = TextWrapping.Wrap;
        }
    }
}
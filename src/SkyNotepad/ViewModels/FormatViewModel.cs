using System.Windows.Input;
using SkyNotepad.Helpers;
using SkyNotepad.Models;
using Windows.UI.Xaml;

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
        public void Wrap()
        {
            if (Format.Wrap == TextWrapping.Wrap)
                Format.Wrap = TextWrapping.NoWrap;

            else
                Format.Wrap = TextWrapping.Wrap;
        }
    }
}
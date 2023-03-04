// Librarys
using Windows.UI.Xaml;
using System.Windows.Input;

// Project Folders
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

        /// <summary>
        /// Loads Commands
        /// </summary>
        /// <param name="document"></param>
        public FormatViewModel(DocumentModel document)
        {
            Document = document;
            Format = new FormatModel();
            WordWrap = new RelayCommand(Wrap);
        }

        /// <summary>
        /// Toggle Word Wrapping on or off
        /// </summary>
        private void Wrap()
        {
            if (Format.Wrap == TextWrapping.Wrap)
                Format.Wrap = TextWrapping.NoWrap;

            else
                Format.Wrap = TextWrapping.Wrap;
        }
    }
}
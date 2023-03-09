// Librarys
using System;
using System.Windows.Input;

// Project Folders
using SkyNotepad.Helpers;
using SkyNotepad.Models;

namespace SkyNotepad.ViewModels
{
    public class EditViewModel
    {
        // Document Model
        public DocumentModel Document { get; set; }

        // Commands
        public ICommand DateTimeCommand { get; }

        /// <summary>
        /// Loads commands
        /// </summary>
        /// <param name="_document">Document Model</param>
        public EditViewModel(DocumentModel _document)
        {
            Document = _document;
            DateTimeCommand = new RelayCommand(PutDateTime);
        }

        /// <summary>
        /// Puts system date and time
        /// </summary>
        private void PutDateTime()
        {
            DateTime dateTime = DateTime.Now;
            Document.SelectedText = dateTime.ToString();
        }
    }
}
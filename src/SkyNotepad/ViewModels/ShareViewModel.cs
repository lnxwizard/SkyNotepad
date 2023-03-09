// Librarys
using System.Windows.Input;
using Windows.ApplicationModel.DataTransfer;

// Project Folders
using SkyNotepad.Helpers;
using SkyNotepad.Services;

namespace SkyNotepad.ViewModels
{
    public class ShareViewModel
    {
        // Commands
        public ICommand ShareCommand { get; }

        /// <summary>
        /// Loads commands
        /// </summary>
        public ShareViewModel()
        {
            ShareCommand = new RelayCommand(Share);
        }

        /// <summary>
        /// Shares text to selected people/e-mail
        /// </summary>
        private void Share()
        {
            SharingService.ShareLoad();
            DataTransferManager.ShowShareUI();
        }
    }
}
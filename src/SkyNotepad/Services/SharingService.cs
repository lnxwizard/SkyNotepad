// Librarys
using Windows.Foundation;
using Windows.ApplicationModel.DataTransfer;

// Project Folders
using SkyNotepad.Models;

namespace SkyNotepad.Services
{
    public class SharingService
    {
        // Document Model
        static DocumentModel Document { get; set; }

        /// <summary>
        /// Loads share service
        /// </summary>
        public static void ShareLoad()
        {
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += new TypedEventHandler<DataTransferManager, DataRequestedEventArgs>(DataRequested);
        }

        /// <summary>
        /// Shares you text to selected people/e-mail
        /// </summary>
        /// <param name="sender">Data Transfer Manager</param>
        /// <param name="e">Data Request</param>
        public static void DataRequested(DataTransferManager sender, DataRequestedEventArgs e)
        {
            DataRequest request = e.Request;
            request.Data.Properties.Title = "SkyNotepad Sharing Service";
            request.Data.Properties.Description = "Share your Document";
            request.Data.Properties.ApplicationName = "SkyNotepad";
            request.Data.SetText(Document.Text.ToString());
        }
    }
}
// Librarys
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using Windows.UI.Popups;
using Windows.UI.Xaml;

// From Project
using SkyNotepad.Helpers;
using SkyNotepad.Models;

namespace SkyNotepad.ViewModels
{
    public class FileViewModel
    {
        // Document Model
        public DocumentModel Document { get; private set; }

        // Menu Items Commands
        public ICommand NewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenCommand { get; }
        public ICommand ExitCommand { get; }

        // File View Model Method
        public FileViewModel(DocumentModel document)
        {
            Document = document;
            NewCommand = new RelayCommand(NewFile);
            SaveCommand = new RelayCommand(SaveFile);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            OpenCommand = new RelayCommand(OpenFile);
            ExitCommand = new RelayCommand(Exit);
        }

        // New Command 
        private void NewFile()
        {
            Document.FileName = "Untitled Text Document";
            Document.FilePath = string.Empty;
            Document.Text = string.Empty;
            Document.IsSaved = false;
        }

        // Save Command
        private async void SaveFile()
        {
            if (Document.IsSaved == true)
            {
                StorageFile storageFile = await StorageApplicationPermissions.FutureAccessList.GetFileAsync(Document.FileToken);
                await FileIO.WriteTextAsync(storageFile, Document.Text);
            }
            else
            {
                SaveFileAs();
            }

        }

        // Save As... Command
        private async void SaveFileAs()
        {
            try
            {
                FileSavePicker savePicker = new FileSavePicker();
                savePicker.SuggestedFileName = "Untitled Text Document";
                savePicker.SuggestedStartLocation = PickerLocationId.Desktop;
                savePicker.FileTypeChoices.Add("Text Document", new List<string>() { ".txt" });
                savePicker.DefaultFileExtension = ".txt";

                StorageFile storageFile = await savePicker.PickSaveFileAsync();
                if (storageFile != null)
                {
                    CachedFileManager.DeferUpdates(storageFile);
                    await FileIO.WriteTextAsync(storageFile, Document.Text);
                    FileUpdateStatus updateStatus = await CachedFileManager.CompleteUpdatesAsync(storageFile);
                    Document.FileToken = StorageApplicationPermissions.FutureAccessList.Add(storageFile);
                    Document.FileName = storageFile.Name;
                    Document.FilePath = storageFile.Path;
                    Document.FileType = storageFile.FileType;
                    Document.DateCreated = storageFile.DateCreated.ToString();
                    Document.IsSaved = true;
                }
            }
            catch
            {
                var message = new MessageDialog("File couldn't save! Try Again.");
                _ = message.ShowAsync();
            }
        }

        // Open... Command
        private async void OpenFile()
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.Desktop;
            openPicker.FileTypeFilter.Add(".txt");

            StorageFile storageFile = await openPicker.PickSingleFileAsync();

            if (storageFile != null)
            {
                var stream = await storageFile.OpenAsync(FileAccessMode.Read);
                using (StreamReader sReader = new StreamReader(stream.AsStream()))
                {
                    Document.Text = sReader.ReadToEnd();
                    Document.FileName = storageFile.Name;
                    Document.FilePath = storageFile.Path;
                    Document.FileType = storageFile.FileType;
                    Document.DateCreated = storageFile.DateCreated.ToString();
                    Document.IsSaved = true;
                }
            }
        }

        // Exit Command
        private void Exit()
        {
            Application.Current.Exit();
        }
    }
}
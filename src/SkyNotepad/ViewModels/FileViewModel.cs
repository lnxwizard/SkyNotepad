﻿// Imported Librarys
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.Storage.Provider;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Project Folders
using SkyNotepad.Helpers;
using SkyNotepad.Models;
using SkyNotepad.Services;

namespace SkyNotepad.ViewModels
{
    public class FileViewModel
    {
        // Document Model
        public DocumentModel Document { get; set; }

        // Menu Items Commands
        public ICommand NewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenCommand { get; }
        public ICommand ExitRequestCommand { get; }
        public ICommand ExitCommand { get; }

        /// <summary>
        /// Loads Commands
        /// </summary>
        /// <param name="_document"></param>
        public FileViewModel(DocumentModel _document)
        {
            Document = _document;
            NewCommand = new RelayCommand(NewFile);
            SaveCommand = new RelayCommand(SaveFile);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            OpenCommand = new RelayCommand(OpenFile);
            ExitRequestCommand = new RelayCommand(ExitRequest);
            ExitCommand = new RelayCommand(Exit); 
            
            CreateNewFile();
        }

        /// <summary>
        /// Creates new file while first run on application
        /// </summary>
        private void CreateNewFile()
        {
            Document.FileName = "Untitled";
            Document.FilePath = string.Empty;
            Document.Text = string.Empty;
            Document.IsSaved = false;
            Document.DateCreated = string.Empty;
            Document.AppTitle = Document.FileName + " - SkyNotepad Preview";
        }

        /// <summary>
        /// Creates new file
        /// </summary>
        private void NewFile()
        {
            Document.FileName = "Untitled";
            Document.FilePath = string.Empty;
            Document.Text = string.Empty;
            Document.IsSaved = false;
            Document.DateCreated = string.Empty;
            Document.AppTitle = Document.FileName + " - SkyNotepad Preview";
        }

        /// <summary>
        /// Saves current file
        /// </summary>
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

        /// <summary>
        /// Saves copy of current file
        /// </summary>
        private async void SaveFileAs()
        {
            try
            {
                FileSavePicker savePicker = new FileSavePicker()
                {
                    SuggestedFileName = "Untitled",
                    SuggestedStartLocation = PickerLocationId.DocumentsLibrary,
                    DefaultFileExtension = ".txt"
                };
                savePicker.FileTypeChoices.Add("Text Document", new List<string>() { ".txt" });
                savePicker.FileTypeChoices.Add("Markdown Source File", new List<string>() { ".md" });

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
                    Document.AppTitle = Document.FileName + " - SkyNotepad Preview";
                }
            }
            catch
            {
                ContentDialog FileSaveUnsuccesfullDialog = new ContentDialog()
                {
                    Title = "Error",
                    CloseButtonText = "OK",
                    PrimaryButtonText = "Try Again",
                    DefaultButton = ContentDialogButton.Close,
                    Content = "File Couldn't Saved! Try Again.",
                    PrimaryButtonCommand = SaveAsCommand
                };
                await FileSaveUnsuccesfullDialog.ShowAsync();
            }
        }

        /// <summary>
        /// Opens file
        /// </summary>
        private async void OpenFile()
        {
            try
            {
                FileOpenPicker openPicker = new FileOpenPicker()
                {
                    ViewMode = PickerViewMode.Thumbnail,
                    SuggestedStartLocation = PickerLocationId.DocumentsLibrary
                };
                // Adds all supported file extensions to open file dialog
                foreach (string FileExtension in FileExtensionProvider.SupportedFileExtensions)
                {
                    openPicker.FileTypeFilter.Add(FileExtension);
                }

                StorageFile storageFile = await openPicker.PickSingleFileAsync();
                if (storageFile != null)
                {
                    var stream = await storageFile.OpenAsync(FileAccessMode.ReadWrite);
                    using (StreamReader sReader = new StreamReader(stream.AsStream()))
                    {
                        Document.Text = sReader.ReadToEnd();
                        Document.FileName = storageFile.Name;
                        Document.FilePath = storageFile.Path;
                        Document.FileType = storageFile.FileType;
                        Document.DateCreated = storageFile.DateCreated.ToString();
                        Document.IsSaved = true;
                        Document.AppTitle = Document.FileName + " - SkyNotepad Preview";
                    }
                }
            }
            catch
            {
                ContentDialog FileOpenUnsuccesfullDialog = new ContentDialog()
                {
                    Title = "Error",
                    CloseButtonText = "OK",
                    PrimaryButtonText = "Try Again",
                    DefaultButton = ContentDialogButton.Close,
                    Content = "File Couldn't Opened! Try Again.",
                    PrimaryButtonCommand = OpenCommand
                };
                await FileOpenUnsuccesfullDialog.ShowAsync();
            }
        }

        /// <summary>
        /// Sends request for exit
        /// </summary>
        private async void ExitRequest()
        {
            ContentDialog saveRememberDialog = new ContentDialog()
            {
                Title = "Warning",
                Content = "Do you want to Exit from SkyNotepad?",
                CloseButtonText = "Cancel",
                PrimaryButtonText = "Exit",
                PrimaryButtonCommand = ExitCommand
            };
            await saveRememberDialog.ShowAsync();
        }

        /// <summary>
        /// Exits from SkyNotepad
        /// </summary>
        private void Exit()
        {
            Application.Current.Exit();
        }
    }
}
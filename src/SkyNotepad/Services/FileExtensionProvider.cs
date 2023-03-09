// Librarys
using System.Collections.Generic;
using Microsoft.Toolkit.Uwp.Helpers;

namespace SkyNotepad.Services
{
    public class FileExtensionProvider
    {
        /// <summary>
        /// List of support file extensions
        /// </summary>
        public static List<string> SupportedFileExtensions = new List<string>()
        {
            ".md",
            ".txt"
        };

        /// <summary>
        /// Checks the Operating System build number 
        /// </summary>
        /// <param name="FileExtension">string</param>
        /// <returns>Returns supported file extensions with lower case</returns>
        public static bool IsFileExtensionSupported(string FileExtension)
        {
            /// <summary>
            /// Supports all file extensions if the Operating System build is greater than 19041 (version 2004 - 20H1)
            /// This is a issue from Project Reunion here is the issue link:
            /// https://github.com/microsoft/ProjectReunion/issues/27
            /// </summary>
            if (SystemInformation.Instance.OperatingSystemVersion.Build >= 19041)
            {
                return true;
            }

            if (string.IsNullOrEmpty(FileExtension))
            {
                return false;
            }

            if (!FileExtension.StartsWith("."))
            {
                FileExtension = "." + FileExtension;
            }

            return SupportedFileExtensions.Contains(FileExtension.ToLower());
        }
    }
}
// Imported Librarys
using Windows.Storage;

namespace SkyNotepad.Services
{
    public static class ApplicationSettings
    {
        /// <summary>
        /// Saves settings
        /// </summary>
        /// <param name="Value">Settings Value</param>
        /// <param name="data"></param>
        public static void SaveSettings(string Value, object data)
        {
            ApplicationData.Current.LocalSettings.Values[Value] = data.ToString();
        }

        /// <summary>
        /// Gets settings
        /// </summary>
        /// <param name="Value">Settings Value</param>
        /// <returns>Returns value</returns>
        public static string GetSettings(string Value)
        {
            return ApplicationData.Current.LocalSettings.Values[Value] as string;
        }
    }
}
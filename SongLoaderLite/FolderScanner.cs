using System.IO;
using System.Collections;

namespace SongLoaderLite
{
    /// <summary>
    /// Folder scanning class, used for detecting songs info files for loading into the applicaiton.
    /// </summary>
    class FolderScanner
    {
        //TODO: add in functions for scanning though the folders


        /// <summary>
        /// Scans for the info.json files in a given path, using the default beatsaver directory structure layout.
        /// </summary>
        /// <param name="SongPath">Path of the custom song directory to scan</param>
        public void ScanForInfoFiles(string songPath)
        {
            foreach (string parentDirectory in Directory.GetDirectories(songPath))
            {
                Logger.Log(Logger.Severity.Info, parentDirectory);
            }
        }

    }
}

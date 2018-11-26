using System;
using System.Collections;
using System.IO;

namespace SongLoaderLite
{
    /// <summary>
    /// Folder scanning class, used for detecting songs info files for loading into the applicaiton.
    /// </summary>
    class FolderScanner
    {

        /// <summary>
        /// Scans for the info.json files in a given path, searching subdirectories and non-standard directory layouts.
        /// </summary>
        /// <param name="SongPath">Path of the custom song directory to scan</param>
        public ArrayList ScanForInfoFiles(string songPath)
        {
            ArrayList jsonInfoFilePath = new ArrayList();

            try
            {
                //first path for main customsongs folder
                foreach (string parentDirectory in Directory.GetDirectories(songPath))
                {
                    try
                    {
                        //Searching subdirectories automatically is more reliable. This helps fix where the songs dont follow standard directory structure.
                        string[] infoFiles = Directory.GetFiles(parentDirectory, "info.json", SearchOption.AllDirectories);

                        if (infoFiles.Length <= 0)
                        {
                            Logger.Log(Logger.Severity.Warn, "Could not file file at " + parentDirectory + " Skipping");
                            continue;
                        }

                        //Add the first one found, there should only be one
                        jsonInfoFilePath.Add(infoFiles[0]);

                    }
                    catch (Exception ex)
                    {
                        //There was likely an issue with the directory name. Either it doesn't exist or it contains invalid characters.
                        //Either way, log it, skip it, and move on.
                        Logger.Log(Logger.Severity.Warn, ex.Message + " Skipping");
                    }
                }
            }
            catch (Exception ex)
            {
                // Something went wrong and none of our songs loaded.
                // Log it, skip it, and return a blank info file path to prevent crashing
                Logger.Log(Logger.Severity.Critical, ex.Message);
            }
            return jsonInfoFilePath;
        }

    }
}

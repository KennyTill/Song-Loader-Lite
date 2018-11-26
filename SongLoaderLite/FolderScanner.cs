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
        //TODO: add in functions for scanning though the folders


        /// <summary>
        /// Scans for the info.json files in a given path, using the default beatsaver directory structure layout.
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
                        string[] infoFiles = Directory.GetFiles(parentDirectory, "info.json", SearchOption.AllDirectories); // see if searching subdirectories is faster/more reliable. This could help fix where the songs dont file standard structure.

                        if (infoFiles.Length <= 0)
                        {
                            Logger.Log(Logger.Severity.Warn, "Could not file file at " + parentDirectory + " Skipping");
                            continue;
                        }

                        jsonInfoFilePath.Add(infoFiles[0]); //add the first one found, there should only be one.

                    }
                    catch (Exception ex)
                    {
                        Logger.Log(Logger.Severity.Warn, ex.Message + " Skipping");
                    }
                }
            }
            catch (Exception ex)
            {
                // something went wrong
                Logger.Log(Logger.Severity.Critical, ex.Message);
            }
            return jsonInfoFilePath;
        }

    }
}

using System.IO;
using System.Collections;
using System;

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

            try {
                //first path for main customsongs folder
                foreach (string parentDirectory in Directory.GetDirectories(songPath))
                {
                    try
                    {
                        // inner path for the song information folder
                        foreach (string songDirectory in Directory.GetDirectories(parentDirectory))
                        { 
                            // where the info.json file should be stored
                            string[] files = Directory.GetFiles(songDirectory, "info.json");
                            if (files.Length > 0)
                            {
                                //we found it, add it to the output list
                                jsonInfoFilePath.Add(files[0]); // snag the first file, in theory there should only be one info file here

                                //TODO: see if it will be faster to load the entire system here, while we have the file locations.
                            }
                            else
                            {
                                Logger.Log(Logger.Severity.Warn, "Could not file file at " + parentDirectory + " Skipping");
                            }

                        }
                    } catch (Exception ex)
                    {
                        Logger.Log(Logger.Severity.Warn, ex.Message + " Skipping");
                    }
                }
            } catch (Exception ex)
            {
                // something went wrong
                Logger.Log(Logger.Severity.Critical, ex.Message);
            }
            return jsonInfoFilePath;
        }

    }
}

using IllusionPlugin;
using System.Collections;
using UnityEngine.SceneManagement;

namespace SongLoaderLite
{
    /// <summary>
    /// Main functions bootstrap here, is the interface used for injection into the main application
    /// </summary>
    public class Plugin : IPlugin
    {
        public string Name => "SongLoaderLite";
        public string Version => "0.0.1";
        private readonly string MENUSCENE = "Menu";

        /// <summary>
        /// Called when the program starts, where we bootstrap in out loading code
        /// </summary>
        public void OnApplicationStart()
        {
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            Logger.Log(Logger.Severity.Info, "Plugin Loaded");
        }

        /// <summary>
        /// This is the event that is called when the scene changes, used for checking if the current scene is the menu
        /// </summary>
        /// <param name="arg0">Unknown at this time</param>
        /// <param name="arg1">Information about the current scene</param>
        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene arg1)
        {
            //TODO: stop loading here if the scene is changed from the menu

            //figure out if we are in the menu
            if (arg1.name == MENUSCENE)
            {
                //we are currently at the menu

                //load up folder scanner to see if we can't get something working when this fires

                FolderScanner scanner = new FolderScanner();
                ArrayList jsonInfoFiles = scanner.ScanForInfoFiles("C:\\Program Files (x86)\\Steam\\steamapps\\common\\Beat Saber\\CustomSongs\\"); // <- can I just point out how stupid it is to have to escape Windows file directories, in a programming language made by microsoft?

                //testing here
                foreach (string file in jsonInfoFiles)
                {
                    //Logger.Log(Logger.Severity.Debug, file);
                }
            }

        }


        /// <summary>
        /// Put cleanup code inside this section, called when the application exits
        /// </summary>
        public void OnApplicationQuit()
        {

            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
        }


        #region Unused
        //These methods are required to be here from inheriting the IPlugin interface

        public void OnLevelWasLoaded(int level)
        {

        }

        public void OnLevelWasInitialized(int level)
        {
        }

        public void OnUpdate()
        {
        }

        public void OnFixedUpdate()
        {
        }
        #endregion
    }
}

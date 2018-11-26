using IllusionPlugin;
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

        /// <summary>
        /// Called when the program starts, where we bootstrap in out loading code
        /// </summary>
        public void OnApplicationStart()
        {
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
        }

        /// <summary>
        /// This is the event that is called when the scene changes, used for checking if the current scene is the menu
        /// </summary>
        /// <param name="arg0">Previous Scene(?)</param>
        /// <param name="arg1">Loaded Scene(?)</param>
        private void SceneManagerOnActiveSceneChanged(Scene arg0, Scene arg1)
        {
            //TODO: stop loading here if the scene is changed from the menu

            //figure out if we are in the menu
            string sceneNames = "Scene Arg 0:" + arg0.name + " Scene Arg 1:" + arg1.name;
            Logger.Log(Logger.Severity.Info, sceneNames);

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

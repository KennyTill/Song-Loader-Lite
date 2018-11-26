using IllusionPlugin;
using UnityEngine.SceneManagement;

namespace SongLoaderLite
{
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

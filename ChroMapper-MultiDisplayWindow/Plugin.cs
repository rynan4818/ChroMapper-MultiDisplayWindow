using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChroMapper_MultiDisplayWindow
{
    [Plugin("Multi Display Window")]
    public class Plugin
    {
        [Init]
        private void Init()
        {
            Debug.Log("Multi Display Window Plugin has loaded!");
            SceneManager.sceneLoaded += SceneLoaded;
        }

        [Exit]
        private void Exit()
        {
            Debug.Log("Camera Movement:Application has closed!");
        }

        private void SceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            if (arg0.buildIndex != 3) // Mapper scene
                return;
            MapEditorUI mapEditorUI = Object.FindObjectOfType<MapEditorUI>();
        }
    }
}

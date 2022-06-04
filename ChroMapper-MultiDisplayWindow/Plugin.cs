using UnityEngine;
using UnityEngine.SceneManagement;
using ChroMapper_MultiDisplayWindow.Component;
using ChroMapper_MultiDisplayWindow.UserInterface;

namespace ChroMapper_MultiDisplayWindow
{
    [Plugin("Multi Display Window")]
    public class Plugin
    {
        public static MultiDisplayController multiDisplayController;
        public static UI _ui;
        [Init]
        private void Init()
        {
            Debug.Log("Multi Display Window Plugin has loaded!");
            SceneManager.sceneLoaded += SceneLoaded;
            _ui = new UI();
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
            if (multiDisplayController != null && multiDisplayController.isActiveAndEnabled)
                return;
            multiDisplayController = new GameObject("MultiDisplayWindow").AddComponent<MultiDisplayController>();
            MapEditorUI mapEditorUI = Object.FindObjectOfType<MapEditorUI>();
            _ui.AddMenu(mapEditorUI);
        }
    }
}

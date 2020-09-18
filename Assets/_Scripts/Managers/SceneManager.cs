using ArcadeMachineInvaders.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ArcadeMachineInvaders.GameManagers
{
    public class SceneManager : Singleton<SceneManager>
    {
        [SerializeField] private string MenuSceneName;
        [SerializeField] private string GameSceneName;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
        public void LoadMainMenuScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(MenuSceneName);
        }

        public void LoadGameScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(GameSceneName);
        }
    }
}

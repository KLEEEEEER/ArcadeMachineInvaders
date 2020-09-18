using ArcadeMachineInvaders.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeMachineInvaders.GameManagers
{
    public class GameManager : Singleton<GameManager>
    {
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.Instance.LoadMainMenuScene();
        }
    }
}
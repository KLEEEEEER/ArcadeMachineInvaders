using ArcadeMachineInvaders.GameManagers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public void OnStartGameButtonPressed()
    {
        SceneManager.Instance.LoadGameScene();
    }
}

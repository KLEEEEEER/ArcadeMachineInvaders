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
    
    public void OnExitButtonPressed()
    {
        Application.Quit();
    }

    public void OnSoundCloudPressed()
    {
        Application.OpenURL("https://soundcloud.com/maxnitals");
    }
    public void OnItchioPressed()
    {
        Application.OpenURL("https://maxnitals.itch.io/");
    }
    public void OnJamInfoPressed()
    {
        Application.OpenURL("https://itch.io/jam/curious-game-jam-2020");
    }
}

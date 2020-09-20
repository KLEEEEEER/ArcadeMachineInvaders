using ArcadeMachineInvaders.GameManagers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text enemiesCount;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private LevelManager levelManager;

    private void OnEnable()
    {
        levelManager.onEnemiesCountChanged.AddListener(UpdateEnemiesCounter);
    }

    private void OnDisable()
    {
        levelManager.onEnemiesCountChanged.RemoveListener(UpdateEnemiesCounter);
    }

    private void UpdateEnemiesCounter(int enemies)
    {
        enemiesCount.text = enemies.ToString();
    }

    public void OnGameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void OnTryAgainButtonPressed()
    {
        SceneManager.Instance.LoadGameScene();
    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
    }

    public void OnWin()
    {
        winScreen.SetActive(true);
    }
}

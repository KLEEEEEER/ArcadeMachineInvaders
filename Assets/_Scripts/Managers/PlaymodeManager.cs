using ArcadeMachineInvaders.GameMode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlaymodeManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform enemiesParent;

    public void OnPlayerMovementPressed(CallbackContext callbackContext)
    {
        Vector2 movement = callbackContext.ReadValue<Vector2>();
        player.Move(movement);
    }

    public void OnPlayerShootPressed(CallbackContext callbackContext)
    {
        if (callbackContext.started)
            //player.Shoot();
            player.StartShooting();

        if (callbackContext.canceled)
            player.StopShooting();
    }
}

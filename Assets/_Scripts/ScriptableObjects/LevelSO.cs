using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Create new Level")]
public class LevelSO : ScriptableObject
{
    [Header("Arcade View")]
    [Range(1,2)]
    public int numberOfKidsNear = 1;

    [Header("Enemies")]
    [Range(10, 50)]
    public int numberOfEnemies = 10;
    public float enemiesMinSpeed = 2f;
    public float enemiesMaxSpeed = 10f;

    [HideInInspector] public ArcadeMachine arcadeMachine;
    [HideInInspector] public Kid kid1;
    [HideInInspector] public Kid kid2;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "Create new Level")]
public class LevelSO : ScriptableObject
{
    [Header("Arcade View")]
    [Range(1,2)]
    public int numberOfBoysNear = 1;

    [Header("Enemies")]
    [Range(10, 50)]
    public int numberOfEnemies = 10;
    public float enemiesSpeed = 10f;
}

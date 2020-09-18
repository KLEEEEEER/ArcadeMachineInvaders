using ArcadeMachineInvaders.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ArcadeMachineInvaders.GameManagers
{
    public class LevelManager : Singleton<LevelManager>
    {
        [SerializeField] private LevelSO[] levels;

        [Header("Points")]
        [SerializeField] private Vector3 startPoint = Vector3.zero;
        [SerializeField] private float pointsOffset = 5f;
        private Vector3 currentPosition;

        [Header("Prefabs")]
        [SerializeField] private GameObject arcadeMachinePrefab;
        [SerializeField] private GameObject[] boysPrefabs;

        private void Start()
        {
            currentPosition = startPoint;
            CreateLevelsMap();
        }

        private void CreateLevelsMap()
        {
            foreach (LevelSO level in levels)
            {
                //GameObject newArcade = new GameObject();
                //newArcade.name = level.name;
                //newArcade.transform.position = currentPosition;
                Instantiate(arcadeMachinePrefab, currentPosition, Quaternion.identity);
                currentPosition.x += pointsOffset;
            }
        }
    }
}
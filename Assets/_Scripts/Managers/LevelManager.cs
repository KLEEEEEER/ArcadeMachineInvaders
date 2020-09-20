using ArcadeMachineInvaders.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ArcadeMachineInvaders.GameManagers
{
    public class LevelManager : Singleton<LevelManager>
    {
        [HideInInspector] public Fixer fixer;
        [SerializeField] private LevelSO[] levels;
        [SerializeField] EnemySpawner spawner;
        [SerializeField] EnemyBulletsObjectPool enemyBulletsObjectPool;
        [SerializeField] UIManager uiManager;

        [Header("Points")]
        [SerializeField] private Vector3 startPoint = Vector3.zero;
        [SerializeField] private float pointsOffset = 5f;
        private Vector3 currentPosition;

        [Header("Prefabs")]
        [SerializeField] private GameObject arcadeMachinePrefab;
        /*[SerializeField] private GameObject kid1Prefab;
        [SerializeField] private GameObject kid2Prefab;*/
        [SerializeField] private GameObject[] kidsPrefabs;
        [SerializeField] private GameObject fixerPrefab;

        WaitForSeconds wait1Second = new WaitForSeconds(1f);
        WaitForSeconds waitHalfSecond = new WaitForSeconds(0.5f);
        int currentLevelNumber = 0;
        private Camera mainCamera;
        [SerializeField] private Transform invadersTable;
        private bool isPlayingCutscene = true;

        private int enemiesSpawned = 0;
        public UnityEvent<int> onEnemiesCountChanged;

        private void Awake()
        {
            if (onEnemiesCountChanged == null)
                onEnemiesCountChanged = new UnityEvent<int>();

            mainCamera = Camera.main;
            currentPosition = startPoint;
            CreateLevelsMap();
        }

        private void Start()
        {
            SoundManager.Instance.PlayBackgroundMusic();
        }

        private void FixedUpdate()
        {
            if (isPlayingCutscene)
            {
                mainCamera.transform.position = fixer.transform.position + fixer.cameraOffset;
            }
        }

        private void OnDestroy()
        {
            onEnemiesCountChanged.RemoveAllListeners();
        }

        public bool IsPlayingCutscene()
        {
            return isPlayingCutscene;
        }

        private void CreateLevelsMap()
        {
            GameObject fixerGO = Instantiate(fixerPrefab, currentPosition, Quaternion.identity);
            fixer = fixerGO.GetComponent<Fixer>();
            currentPosition.x += pointsOffset;

            foreach (LevelSO level in levels)
            {
                GameObject arcadeMachine = Instantiate(arcadeMachinePrefab, currentPosition, Quaternion.identity);
                level.arcadeMachine = arcadeMachine.GetComponent<ArcadeMachine>();
                currentPosition.x += pointsOffset;

                for (int i = 1; i < level.numberOfKidsNear + 1; i++)
                {
                    switch (i) 
                    {
                        case 1:
                            Transform kid1Place = arcadeMachine.transform.Find("Kid1Place");
                            GameObject kid1 = Instantiate(kidsPrefabs[Random.Range(0, kidsPrefabs.Length)], kid1Place.position, Quaternion.identity);
                            level.kid1 = kid1.GetComponent<Kid>();
                            break;
                        case 2:
                            Transform kid2Place = arcadeMachine.transform.Find("Kid2Place");
                            GameObject kid2 = Instantiate(kidsPrefabs[Random.Range(0, kidsPrefabs.Length)], kid2Place.position, Quaternion.identity);
                            level.kid2 = kid2.GetComponent<Kid>();
                            break;
                    }
                }
            }

            StartCoroutine(DisableAllArcadeMachines());
            StartCoroutine(FixerToNextLevel(levels[currentLevelNumber]));
        }

        IEnumerator DisableAllArcadeMachines()
        {
            yield return wait1Second;
            foreach (LevelSO level in levels)
            {
                level.arcadeMachine.Broke();
                level.kid1.Speak();
                if (level.kid2 != null)
                    level.kid2.Speak();
                yield return wait1Second;
            }
        }

        public void ToNextLevel()
        {
            levels[currentLevelNumber].arcadeMachine.Fixed();
            levels[currentLevelNumber].kid1.StopSpeaking();
            if (levels[currentLevelNumber].kid2 != null)
                levels[currentLevelNumber].kid2.StopSpeaking();

            if (currentLevelNumber + 1 >= levels.Length)
            {
                BackToCutscene();
                fixer.Stand();
                uiManager.OnWin();
                return;
            }

            currentLevelNumber += 1;
            StartCoroutine(FixerToNextLevel(levels[currentLevelNumber]));
        }

        IEnumerator FixerToNextLevel(LevelSO level)
        {
            BackToCutscene();
            yield return wait1Second;
            spawner.SpawnLevel(level);
            enemiesSpawned = level.numberOfEnemies;
            onEnemiesCountChanged.Invoke(enemiesSpawned);
            fixer.Stand();
            yield return wait1Second;
            Vector3 fixingPosition = level.arcadeMachine.GetFixingPosition();
            Vector3 fixerStartPosition = fixer.transform.position;

            float step = (fixer.speed / (fixerStartPosition - fixingPosition).magnitude) * Time.fixedDeltaTime;
            float t = 0;
            while (t <= 1.0f)
            {
                t += step; // Goes from 0 to 1, incrementing by step each time
                fixer.transform.position = Vector3.Lerp(fixerStartPosition, fixingPosition, t); // Move objectToMove closer to b
                yield return new WaitForFixedUpdate();        // Leave the routine and return here in the next frame
            }
            fixer.transform.position = fixingPosition;
            fixer.Fixing();
            yield return wait1Second;
            ToPlayMode();
            //yield return new WaitForSeconds(5f);
            //ToNextLevel();
        }

        public void OnEnemyKilled()
        {
            enemiesSpawned--;
            onEnemiesCountChanged.Invoke(enemiesSpawned);
            if (enemiesSpawned == 0)
            {
                enemyBulletsObjectPool.DiactivateAll();
                ToNextLevel();
            }
        }

        private void ToPlayMode()
        {
            isPlayingCutscene = false;
            Vector3 newCameraPosition = invadersTable.position;
            newCameraPosition.z = -10f;
            mainCamera.transform.position = newCameraPosition;
            SoundManager.Instance.SetPlaymodeSnapshot();
        }

        private void BackToCutscene()
        {
            isPlayingCutscene = true;
            SoundManager.Instance.SetCutsceneSnapshot();
        }
    }
}
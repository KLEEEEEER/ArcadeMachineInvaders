using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private BoxCollider2D enemySpawnBounds;
    [SerializeField] private ObjectPool enemyPool;

    public void SpawnLevel(LevelSO level)
    {
        enemyPool.DiactivateAll();

        for (int i = 0; i < level.numberOfEnemies; i++)
        {
            GameObject enemy = enemyPool.GetPooledObject();
            if (enemy != null)
            {
                Enemy comp = enemy.GetComponent<Enemy>();
                if (comp != null)
                {
                    comp.SetSpeed(level.enemiesMinSpeed, level.enemiesMaxSpeed);
                }
                enemy.transform.position = GetRandomEnemySpawnPoint();
                enemy.SetActive(true);
            }
        }
    }

    private Vector3 GetRandomEnemySpawnPoint()
    {
        return new Vector3
            (
                Random.Range(enemySpawnBounds.bounds.min.x, enemySpawnBounds.bounds.max.x),
                Random.Range(enemySpawnBounds.bounds.min.y, enemySpawnBounds.bounds.max.y),
                0
            );
    }
}

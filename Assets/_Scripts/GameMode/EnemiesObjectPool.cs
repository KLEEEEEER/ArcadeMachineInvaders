using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesObjectPool : ObjectPool
{

    [SerializeField] private Transform leftBoundPoint;
    [SerializeField] private Transform rightBoundPoint;
    [SerializeField] EnemyBulletsObjectPool enemiesBulletsObjectPool;
    [SerializeField] ObjectPool deathEffectPool;
    public override void SetObjectsProperties(GameObject poolGameObject)
    {
        Enemy enemy = poolGameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.leftBoundPoint = leftBoundPoint;
            enemy.rightBoundPoint = rightBoundPoint;
            enemy.enemiesBulletsObjectPool = enemiesBulletsObjectPool;
            enemy.deathEffectPool = deathEffectPool;
        }
    }
}

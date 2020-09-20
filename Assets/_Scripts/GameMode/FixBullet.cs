using ArcadeMachineInvaders.GameManagers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixBullet : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private float timeToHide = 2f;
    private float timeElapsed;

    private void OnEnable()
    {
        timeElapsed = 0f;
    }
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeToHide) gameObject.SetActive(false);
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null && !enemy.IsDead())
        {
            gameObject.SetActive(false);
            enemy.Kill();
            LevelManager.Instance.OnEnemyKilled();
        }
    }
}

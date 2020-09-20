using ArcadeMachineInvaders.GameMode;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private float timeToHide = 6f;
    private float timeElapsed;

    private void OnEnable()
    {
        timeElapsed = 0f;
    }
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeToHide) gameObject.SetActive(false);
        transform.position -= Vector3.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.Kill();
            gameObject.SetActive(false);
        }
    }
}

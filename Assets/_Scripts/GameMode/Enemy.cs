using ArcadeMachineInvaders.GameManagers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Vector2 speedRandomRange = new Vector2(5f, 15f);
    private float speed = 0f;
    private Vector3 currentDirection;

    public Transform leftBoundPoint;
    public Transform rightBoundPoint;

    private bool isDead = false;
    private float shootPercentage = 0.001f;
    [SerializeField] private float timeBetweenShots = 1f;
    private float timeElapsed = 0f;
    private float waitAfterCutscene = 1f;
    private bool afterCutscene = true;
    public EnemyBulletsObjectPool enemiesBulletsObjectPool;
    [SerializeField] public ObjectPool deathEffectPool;

    [SerializeField] private Text bodyText;
    private char[] bugSymbols = new char[] { 'Ẋ', 'ᵬ', 'ᶚ', 'ὢ', '♠', '♯', '√' };

    public bool IsDead()
    {
        return isDead;
    }

    public void Kill()
    {
        gameObject.SetActive(false);

        GameObject deathEffect = deathEffectPool.GetPooledObject();
        deathEffect.transform.position = transform.position;
        deathEffect.SetActive(true);

        SoundManager.Instance.PlayEnemyDeathSound();
        isDead = true;
    }

    private void OnEnable()
    {
        afterCutscene = true;
        bodyText.text = bugSymbols[Random.Range(0, bugSymbols.Length)].ToString();
        isDead = false;
        //speed = Random.Range(speedRandomRange.x, speedRandomRange.y);
        currentDirection = new Vector2(Random.Range(-1, 2), 0);
    }

    public void SetSpeed(float min, float max)
    {
        speed = Random.Range(min, max);
    }

    private void Update()
    {
        if (LevelManager.Instance.IsPlayingCutscene())
        {
            timeElapsed = 0f;
            return;
        }
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeBetweenShots && Random.value <= shootPercentage) 
        { 
            Shoot();
            //Debug.Log($"Random.value({Random.value}) <= shootPercentage({shootPercentage})");
        }
        Vector3 newPosition = gameObject.transform.position + currentDirection * speed * Time.deltaTime;
        if (newPosition.x >= rightBoundPoint.position.x || newPosition.x <= leftBoundPoint.position.x) ChangeDirection();
        transform.position = newPosition;
    }

    private void ChangeDirection()
    {
        currentDirection.x *= -1;
    }

    private void Shoot()
    {
        if (LevelManager.Instance.IsPlayingCutscene()) 
        {
            return;
        }
        if (afterCutscene && timeElapsed < waitAfterCutscene)
        {
            Debug.Log("timeElapsed < waitAfterCutscene");
            return;
        }
        afterCutscene = false;

        if (timeElapsed <= timeBetweenShots) return;

        Debug.Log("Shoot!");
        GameObject bullet = enemiesBulletsObjectPool.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = transform.position;
            bullet.SetActive(true);
            timeElapsed = 0f;
        }
    }
}

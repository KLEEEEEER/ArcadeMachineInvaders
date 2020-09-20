using ArcadeMachineInvaders.GameManagers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace ArcadeMachineInvaders.GameMode
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        public Vector3 moveDirection;
        [SerializeField] private GameObject bulletPrefab;
        [SerializeField] private Transform leftBoundPoint;
        [SerializeField] private Transform rightBoundPoint;
        [SerializeField] private BulletsObjectPool bulletsObjectPool;

        [SerializeField] UnityEvent OnPlayerKilled;

        [SerializeField] public ObjectPool deathEffectPool;

        private float timeElapsed = 0f;
        private float timeBetweenShots = 0.5f;

        private bool isDead = false;
        private bool isShootingPressed = false;

        public void Move(Vector3 direction)
        {
            if (isDead) return;

            moveDirection = direction;
        }

        public void Shoot()
        {
            if (LevelManager.Instance.IsPlayingCutscene()) return;
            //if (isDead) return;
            //if (timeElapsed <= timeBetweenShots) return;

            GameObject bullet = bulletsObjectPool.GetPooledObject();
            if (bullet != null)
            {
                SoundManager.Instance.PlayPlayerShootSound();
                bullet.transform.position = transform.position;
                bullet.SetActive(true);
                timeElapsed = 0f;
            }
        }

        public void Kill()
        {
            isDead = true;
            SoundManager.Instance.PlayPlayerDeathSound();

            GameObject deathEffect = deathEffectPool.GetPooledObject();
            deathEffect.transform.position = transform.position;
            deathEffect.SetActive(true);

            OnPlayerKilled.Invoke();
            gameObject.SetActive(false);
        }

        private void Update()
        {
            if (LevelManager.Instance.IsPlayingCutscene()) return;
            timeElapsed += Time.deltaTime;

            if (isShootingPressed && timeElapsed >= timeBetweenShots && !isDead) Shoot();

            Vector3 newPosition = gameObject.transform.position + moveDirection * speed * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, leftBoundPoint.position.x, rightBoundPoint.position.x);
            gameObject.transform.position = newPosition;
        }

        public void StartShooting()
        {
            isShootingPressed = true;
        }

        public void StopShooting()
        {
            isShootingPressed = false;
        }
    }
}
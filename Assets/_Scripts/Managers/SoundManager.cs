using ArcadeMachineInvaders.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace ArcadeMachineInvaders.GameManagers
{
    public class SoundManager : Singleton<SoundManager>
    {
        [SerializeField] private AudioSource playerShoot;
        [SerializeField] private AudioSource playerDied;
        [SerializeField] private AudioSource enemyDied;
        [SerializeField] private AudioSource backgroundMusic;

        [SerializeField] private AudioMixerSnapshot cutsceneMode;
        [SerializeField] private AudioMixerSnapshot playMode;
        [SerializeField] private float transitionTime = 0.1f;
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            cutsceneMode.TransitionTo(0.1f);
        }

        public void PlayPlayerShootSound()
        {
            playerShoot.Play();
        }

        public void PlayPlayerDeathSound()
        {
            playerDied.Play();
        }

        public void PlayEnemyDeathSound()
        {
            enemyDied.Stop();
            enemyDied.Play();
        }

        public void PlayBackgroundMusic()
        {
            backgroundMusic.Stop();
            backgroundMusic.Play();
        }

        public void SetCutsceneSnapshot()
        {
            cutsceneMode.TransitionTo(transitionTime);
        }

        public void SetPlaymodeSnapshot()
        {
            playMode.TransitionTo(transitionTime);
        }
    }
}


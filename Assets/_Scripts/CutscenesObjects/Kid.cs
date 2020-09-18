using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite playingSprite;
    [SerializeField] private Sprite speakingSprite;
    [SerializeField] private GameObject speakingCloudGameObject;

    public void Speak()
    {
        spriteRenderer.sprite = speakingSprite;
        speakingCloudGameObject.SetActive(true);
    }

    public void StopSpeaking()
    {
        spriteRenderer.sprite = playingSprite;
        speakingCloudGameObject.SetActive(false);
    }
}

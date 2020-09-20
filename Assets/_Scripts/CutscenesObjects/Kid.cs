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
        if (speakingCloudGameObject != null)
            speakingCloudGameObject.SetActive(true);
    }

    public void StopSpeaking()
    {
        spriteRenderer.sprite = playingSprite;
        if (speakingCloudGameObject != null)
            speakingCloudGameObject.SetActive(false);
    }
}

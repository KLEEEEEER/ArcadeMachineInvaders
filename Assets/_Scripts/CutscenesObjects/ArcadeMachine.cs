using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMachine : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite powerOnSprite;
    [SerializeField] private Sprite powerOffSprite;

    public void Broke()
    {
        spriteRenderer.sprite = powerOffSprite;
    }

    public void Fixed()
    {
        spriteRenderer.sprite = powerOnSprite;
    }
}

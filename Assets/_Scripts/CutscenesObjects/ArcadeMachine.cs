using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMachine : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite powerOnSprite;
    [SerializeField] private Sprite powerOffSprite;
    [SerializeField] private Transform fixingPosition;

    public void Broke()
    {
        spriteRenderer.sprite = powerOffSprite;
    }

    public void Fixed()
    {
        spriteRenderer.sprite = powerOnSprite;
    }

    public Vector3 GetFixingPosition()
    {
        return fixingPosition.position;
    }
}

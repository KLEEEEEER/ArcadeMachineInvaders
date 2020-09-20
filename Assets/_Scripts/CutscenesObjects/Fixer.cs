using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fixer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite standingSprite;
    [SerializeField] private Sprite fixingSprite;
    [SerializeField] public float speed;
    [SerializeField] public Vector3 cameraOffset = new Vector3(0f, 3f, -10f);
    
    public void Stand()
    {
        spriteRenderer.sprite = standingSprite;
        spriteRenderer.sortingOrder = 6;
    }

    public void Fixing()
    {
        spriteRenderer.sprite = fixingSprite;
        spriteRenderer.sortingOrder = 1;
    }
}

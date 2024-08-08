using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteFlip : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Sprite leftSprite;

    [SerializeField]
    Sprite rightSprite;

    [SerializeField]
    Rigidbody2D body;

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.sprite = body.velocity.x >= 0 ? rightSprite : leftSprite;
    }
}

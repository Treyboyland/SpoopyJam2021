using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleIfInvincible : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer sprite;

    [SerializeField]
    Player player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SetAlpha(player.IsInvincible && !player.IsDead ? 1 : 0);
    }

    void SetAlpha(float a)
    {
        var color = sprite.color;
        color.a = a;
        sprite.color = color;
    }
}

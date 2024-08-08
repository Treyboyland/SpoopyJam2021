using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRandomizer : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    List<Sprite> possibleSprites;

    private void OnEnable()
    {
        var index = UnityEngine.Random.Range(0, possibleSprites.Count);
        spriteRenderer.sprite = possibleSprites[index];
    }
}

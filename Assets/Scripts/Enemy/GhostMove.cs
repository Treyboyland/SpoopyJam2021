using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    [SerializeField]
    Vector2 movementRange;

    [SerializeField]
    Vector2 secondsBetweenMoves;

    [SerializeField]
    Rigidbody2D body;


    float elapsed = 0;

    float currentMoveTime = 0;

    bool moving = false;

    private void OnEnable()
    {
        moving = false;
        ResetTime();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= currentMoveTime && !moving)
        {
            ResetTime();
            StartCoroutine(Move());
        }
    }

    void ResetTime()
    {
        elapsed = 0;
        currentMoveTime = UnityEngine.Random.Range(secondsBetweenMoves.x, secondsBetweenMoves.y);
    }

    IEnumerator Move()
    {
        moving = true;
        var target = Player.PlayerInstance.transform.position;
        var magnitude = UnityEngine.Random.Range(movementRange.x, movementRange.y);
        var movementVector = (magnitude * (target - transform.position).normalized) + transform.position;

        var start = transform.position;

        float elapsed = 0;

        while (elapsed < 1)
        {
            elapsed += Time.deltaTime;
            body.MovePosition(Vector3.Lerp(start, movementVector, elapsed));
            yield return null;
        }
        body.MovePosition(movementVector);
        moving = false;
    }
}

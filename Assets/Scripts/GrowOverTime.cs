using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowOverTime : MonoBehaviour
{
    [SerializeField]
    float initialScale;

    [SerializeField]
    float finalScale;

    [SerializeField]
    float secondsToMove;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(Grow());
        }
    }

    IEnumerator Grow()
    {
        transform.localScale = initialScale.ScaleVector();
        float elapsed = 0;
        yield return null;

        while (elapsed < secondsToMove)
        {
            elapsed += Time.deltaTime;
            transform.localScale = Vector3.Lerp(initialScale.ScaleVector(), finalScale.ScaleVector(), elapsed / secondsToMove);
            yield return null;
        }

        gameObject.SetActive(false);
    }
}

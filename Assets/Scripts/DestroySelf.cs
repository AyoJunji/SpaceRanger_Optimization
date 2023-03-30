using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    private float duration = 1.5f;
    void Start()
    {
        StartCoroutine(DelayedDeath(duration));
    }
    IEnumerator DelayedDeath(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    private float timer = 0;
    public float timeLimit = 1.5f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= timeLimit)
        {
            Destroy(gameObject);
        }
    }
}

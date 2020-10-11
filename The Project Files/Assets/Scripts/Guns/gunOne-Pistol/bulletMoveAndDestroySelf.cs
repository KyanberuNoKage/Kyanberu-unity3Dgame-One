using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMoveAndDestroySelf : MonoBehaviour
{
    private float timer = 0;
    public float bulletSpeed = 100;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 3)
        {
            Destroy(gameObject);
        }

        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}

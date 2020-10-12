using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMoveAndDestroySelf : MonoBehaviour
{
    private float timer = 0;
    public float bulletSpeed = 1;
    private Rigidbody myRB;
    public GameObject bulletHitSystem;

    void FixedUpdate()
    {
        DestroyTimer();

        MoveBullet();
    }

    void MoveBullet()
    {
        //Move Bullet Forward Based On The Direction The Bullets Facing.
        myRB = gameObject.GetComponent<Rigidbody>();
        myRB.MovePosition(myRB.transform.position + myRB.transform.forward * Time.deltaTime * bulletSpeed);
    }

    void DestroyTimer()
    {
        //Destroy Bullet After Time.
        timer += Time.deltaTime;

        if (timer >= 3)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name != "1stPersonPlayer" /*&& other.gameObject.tag != "enemy"*/)
        {
            //Destination - Oragin.
            Vector3 perpendicularToOther = other.gameObject.transform.position - gameObject.transform.position;
            Quaternion perpendicularRotation = Quaternion.LookRotation(perpendicularToOther, Vector3.up);

            Instantiate(bulletHitSystem, gameObject.transform.position, perpendicularRotation);

            Destroy(gameObject);
        }
    }
}

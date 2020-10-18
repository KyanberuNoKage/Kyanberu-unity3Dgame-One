using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMoveAndDestroySelf : MonoBehaviour
{
    private float timer = 0;
    public float bulletSpeed = 200;
    private Rigidbody myRB;
    public GameObject bulletHitSystem;
    public GameObject bloodHitSystem;
    public LayerMask playermask;
    public float bulletRayDistance = 1f;
    public float offset = 1;

    private RaycastHit hitInfo;

    void Start()
    {
        bloodHitSystem = GameObject.Find("bloodSystemPlaceholder").gameObject.GetComponent<ParticleSystemQuickFixScript>().bloodObject;
    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        DestroyTimer();

        MoveBullet();

        BulletRay();
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

    void BulletRay()
    {
        //Local Forwards Position Increaced By An Offset Of 0.7.
        Debug.DrawRay(transform.localPosition + transform.forward * 0.7f, transform.forward * bulletRayDistance, Color.red);

        if (Physics.Raycast(transform.localPosition + transform.forward * 0.7f, transform.forward, out hitInfo, bulletRayDistance))
        {
            if (hitInfo.collider.gameObject.tag != "1stPersonPlayer" && hitInfo.collider.isTrigger != true)
            {
                //Point to face towards - Oragin of rotation = Direction Vector.//
                Vector3 perpendicularToOther = gameObject.transform.position - hitInfo.point;
                Quaternion perpendicularRotation = Quaternion.LookRotation(perpendicularToOther, Vector3.up);

                if (hitInfo.collider.gameObject.tag == "enemy")
                {
                    GameObject enemy = hitInfo.collider.gameObject;
                    enemy.GetComponent<MobHealth>().health -= 50;

                    Instantiate(bloodHitSystem, gameObject.transform.position, perpendicularRotation);

                    Debug.Log("Enemy Hit");

                    Destroy(gameObject);
                }
                else if(hitInfo.collider.gameObject.tag != "enemy")
                {
                    Instantiate(bulletHitSystem, gameObject.transform.position, perpendicularRotation);

                    Debug.Log("Wall Hit, u hit " + hitInfo.collider.gameObject.tag);

                    Destroy(gameObject);
                }

            }
        }
    }
}

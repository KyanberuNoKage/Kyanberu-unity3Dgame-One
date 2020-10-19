using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobMovementAndStates : MonoBehaviour
{
    private GameObject my;
    private GameObject player;
    private SphereCollider sCollider;
    private Animator mobAnimator;
    private Vector3 rotationMask = new Vector3(0, 1, 0);

    private float timerTime = 0;
    public GameObject bulletPrefab;
    public GameObject bulletSpawnObject;

    // Start is called before the first frame update
    void Start()
    {
        my = gameObject;
        mobAnimator = gameObject.GetComponent<Animator>();
        gameObject.AddComponent<SphereCollider>();
        sCollider = gameObject.GetComponent<SphereCollider>();
        sCollider.isTrigger = true;
        sCollider.radius = 25;
        player = GameObject.Find("1stPersonPlayer").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        attackState();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "1stPersonPlayer")
        {
            mobAnimator.SetBool("attackBool",true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "1stPersonPlayer")
        {
            mobAnimator.SetBool("attackBool", false);
        }
    }

    void attackState()
    {
        if (mobAnimator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            //direction = point to face towards - start position (oragin)//
            Vector3 direction = (player.transform.position - new Vector3(0, 1, 0)) - my.transform.position;

            Vector3 lookAtRotation = Quaternion.LookRotation(direction).eulerAngles;
            transform.rotation = Quaternion.Euler(Vector3.Scale(lookAtRotation, rotationMask));
            my.transform.Find("Arm").gameObject.transform.rotation = Quaternion.LookRotation(direction);

            timer(direction);

        }
        else
        {
            timerTime = 0;
        }
    }

    void timer(Vector3 direction)
    {
        timerTime += Time.deltaTime;

        if (timerTime >= Random.Range(2, 5))
        {
            Instantiate(bulletPrefab, bulletSpawnObject.transform.position, Quaternion.LookRotation(player.transform.position - bulletSpawnObject.transform.position, Vector3.up));
            timerTime = 0;
        }
    }
}

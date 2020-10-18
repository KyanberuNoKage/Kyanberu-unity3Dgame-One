using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobMovementAndStates : MonoBehaviour
{
    private GameObject my;
    private GameObject player;
    private SphereCollider sCollider;
    private Animator mobAnimator;
    private int zero = 0;
    private Vector3 rotationMask = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        my = gameObject;
        mobAnimator = gameObject.GetComponent<Animator>();
        gameObject.AddComponent<SphereCollider>();
        sCollider = gameObject.GetComponent<SphereCollider>();
        sCollider.isTrigger = true;
        sCollider.radius = 15;
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
            mobAnimator.SetTrigger("attackState");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "1stPersonPlayer")
        {
            mobAnimator.SetTrigger("attackState");
        }
    }

    void attackState()
    {
        if (mobAnimator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            //direction = point to face towards - start position (oragin)//
            Vector3 direction = (player.transform.position - new Vector3(0, 1, 0)) - my.transform.position;
            //my.transform.rotation = Quaternion.Euler(my.transform.eulerAngles.x, Quaternion.LookRotation(direction).y, my.transform.eulerAngles.z);

            Vector3 lookAtRotation = Quaternion.LookRotation(direction).eulerAngles;
            transform.rotation = Quaternion.Euler(Vector3.Scale(lookAtRotation, rotationMask));
            my.transform.Find("Arm").gameObject.transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}

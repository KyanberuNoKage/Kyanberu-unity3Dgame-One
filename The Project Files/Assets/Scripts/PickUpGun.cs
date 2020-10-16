using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGun : MonoBehaviour
{
    private string myTag;
    private SphereCollider sCollider;

    // Start is called before the first frame update
    void Start()
    {
        myTag = gameObject.tag;
        gameObject.AddComponent<SphereCollider>();
        sCollider = gameObject.GetComponent<SphereCollider>();
        sCollider.isTrigger = true;
        sCollider.radius = 30;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == "1stPersonPlayer" && Input.GetKey(KeyCode.E))
        {
            playerGetGun();
        }
    }

    void playerGetGun()
    {
        List<GameObject> guns = GameObject.Find("GunHolsterObject").GetComponent<PlayerGunSwap>().gunsInHolster;

        foreach (GameObject item in guns)
        {
            if (item.tag == myTag)
            {
                item.GetComponent<GunPickedUp>().isPickedUp = true;

                Destroy(gameObject);
            }
        }

    }
}

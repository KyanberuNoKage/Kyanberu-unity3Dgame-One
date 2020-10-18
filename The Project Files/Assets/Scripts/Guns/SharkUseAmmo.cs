using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkUseAmmo : MonoBehaviour
{
    private GameObject shark;
    public GameObject sharkAmmo;
    private GunTwoScript ammoScript;
    private float ammoCount;
    private float stepLength;
    private Vector3 newPos;
    private bool onlyMoveOnceBool = true;

    public GameObject particleSpawnObj;
    public GameObject gunFireParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        shark = gameObject;
        //sharkAmmo = shark.transform.Find("Ammo").gameObject;
        ammoScript = gameObject.GetComponent<GunTwoScript>();
        ammoCount = ammoScript.maxAmmoCount;
        stepLength = 3.45f / ammoCount;
        Debug.Log(stepLength);
    }

    // Update is called once per frame
    void Update()
    {
        if (onlyMoveOnceBool && ammoScript.fireIntervalTimerOn)
        {
            sharkAmmo.transform.localPosition -= new Vector3(stepLength, 0, 0);
            Instantiate( gunFireParticleSystem, particleSpawnObj.transform.position, particleSpawnObj.transform.rotation);
            onlyMoveOnceBool = false;
        }

        onlyMoveOnceBool = ammoScript.canFire;

        if (ammoScript.isReloading)
        {
            shark.GetComponent<Animator>().enabled = true;
        }
        else
        {
            shark.GetComponent<Animator>().enabled = false;
        }

        
    }
}

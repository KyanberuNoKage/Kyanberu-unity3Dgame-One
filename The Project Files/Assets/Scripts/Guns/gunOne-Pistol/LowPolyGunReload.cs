using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowPolyGunReload : MonoBehaviour
{
    private GameObject my;
    private GameObject particleSpawn;
    private gunOneScript myGunScript;
    public GameObject particleSystem;
    private GameObject theParticleSystem;

    private Animator myAnimatior;

    private bool particleSpaenOnce = false;
    private bool isInstanciated = false;

    // Start is called before the first frame update
    void Start()
    {
        my = gameObject;
        particleSpawn = my.transform.Find("reloadSystemSpawn").gameObject;
        myGunScript = my.GetComponent<gunOneScript>();
        myAnimatior = my.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myGunScript.isReloading && !particleSpaenOnce)
        {
            theParticleSystem = Instantiate(particleSystem, particleSpawn.transform.position, my.transform.localRotation);
            isInstanciated = true;
            particleSpaenOnce = true;
        }

        if (!myGunScript.isReloading)
        {
            particleSpaenOnce = false;
        }

        if (isInstanciated)
        {
            theParticleSystem.transform.position = particleSpawn.transform.position;
        }

        if (myGunScript.fireIntervalTimerOn)
        {
            myAnimatior.enabled = true;
        }
        else
        {
            myAnimatior.enabled = false;
        }
    }
}

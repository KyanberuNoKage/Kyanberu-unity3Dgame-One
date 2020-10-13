using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTwoScript : MonoBehaviour
{
    private Transform playersCamera;
    private GameObject thisGun;
    private Transform bulletSpawn;
    public GameObject bulletPrefab;

    //For Ironsight And Hip Fire.
    private Vector3 hipFirePosition;
    private Vector3 ironsightFirePosition;

    //Vars For Ammo And Reloading.
    public int AmmoCount = 6;
    private int maxAmmoCount;
    private bool canFire = true;
    private bool isReloading = false;
    private float reloadTimerFloat = 0;
    public float ReloadSpeed = 2;
    private Quaternion reload_tilt;
    private Quaternion original_tilt;
    public Vector3 reloadPosition;

    //The intervel between firing bullets.
    public float fireInterval = 0.1f;
    private bool fireIntervalTimerOn = false;
    private float fireIntervalTimer = 0;

    private void Start()
    {
        #region Reload Variables
        original_tilt = gameObject.transform.localRotation;
        reload_tilt = Quaternion.Euler(-45, -45, 0);
        reloadPosition = transform.localPosition + new Vector3(-0.1f, 0.3f, 0);
        #endregion

        #region GameObject Variables
        playersCamera = GameObject.Find("1stPersonPlayer").transform.Find("Player Camera");
        thisGun = gameObject;
        bulletSpawn = thisGun.transform.Find("bulletSpawnObj");
        #endregion

        #region Hip Fire And Ireonsights Variables
        hipFirePosition = new Vector3(0.8f, -0.6f, 1.89f);
        ironsightFirePosition = new Vector3(0, -0.3f, 1.41f);
        #endregion

        #region Ammo Count
        maxAmmoCount = AmmoCount;
        Debug.Log("Ammo Count: " + AmmoCount);
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        //Var For Temp Ammo Count Display.
        int tempAmmoCount = AmmoCount;

        //Method To Fire A Bullet From The Gun.
        FireGun();

        //Method To Switch To And From Firing From The Hip Or From Ironsights.
        ironSights();

        //Method For Timer That Stops The Player Firing The Gun As Fast As The Can Tap The Mouse Button.
        intervalTimer();

        //Method For Relaoding.
        reload();

        //Method For Reload Timer.
        reloadTimer();

        //Temp Ammo Count Display.
        if (tempAmmoCount != AmmoCount)
        {
            tempAmmoCount = AmmoCount;
            Debug.Log("Ammo Count: " + AmmoCount);
        }

    }

    #region Methods
    void FireGun()
    {
        if (Input.GetButton("Fire1") && canFire && AmmoCount > 0)
        {
            canFire = false;
            fireIntervalTimer = 0;
            fireIntervalTimerOn = true;
            AmmoCount -= 1;
            Instantiate(bulletPrefab, bulletSpawn.position, playersCamera.rotation);
        }
    }

    void ironSights()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            transform.localPosition = ironsightFirePosition;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            transform.localPosition = hipFirePosition;
        }
    }

    void intervalTimer()
    {
        if (fireIntervalTimerOn)
        {
            fireIntervalTimer += Time.deltaTime;
        }
        else
        {
            fireIntervalTimer = 0;
        }

        if (fireIntervalTimer >= fireInterval)
        {
            canFire = true;
            fireIntervalTimerOn = false;
        }
    }

    void reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && AmmoCount < maxAmmoCount)
        {
            canFire = false;
            isReloading = true;
        }
    }

    void reloadTimer()
    {
        if (isReloading)
        {
            reloadTimerFloat += Time.deltaTime;

            transform.localRotation = reload_tilt;
            transform.localPosition = reloadPosition;
        }
        else
        {
            transform.localRotation = original_tilt;
            transform.localPosition = hipFirePosition;
            reloadTimerFloat = 0;
        }

        if (reloadTimerFloat >= ReloadSpeed)
        {
            Debug.Log("Realoaded!!!");
            AmmoCount = maxAmmoCount;
            canFire = true;
            isReloading = false;
        }
    }

    #endregion
}

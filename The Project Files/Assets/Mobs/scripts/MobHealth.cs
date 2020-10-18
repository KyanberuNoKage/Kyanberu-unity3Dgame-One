using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHealth : MonoBehaviour
{
    public float health = 500;
    private float currentHealth;

    public GameObject deathParticleSpawn;
    public GameObject deathParticleSystem;

    public bool KillMob = false;


    private void Start()
    {
        currentHealth = health;
    }

    private void Update()
    {
        if (currentHealth != health)
        {
            Debug.Log("Mob Damaged!");
            currentHealth = health;
        }

        if (currentHealth <= 0)
        {
            Instantiate(deathParticleSystem, deathParticleSpawn.transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
        }

        killMobFromEditor();
    }

    void killMobFromEditor()
    {
        if (KillMob)
        {
            health -= health;
            KillMob = false;
        }
    }
}

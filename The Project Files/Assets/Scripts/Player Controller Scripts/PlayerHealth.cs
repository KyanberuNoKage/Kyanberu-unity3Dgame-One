using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 500;
    private float currentHealth;
    public float maxHealth;

    public GameObject deathParticleSpawn;
    public GameObject deathParticleSystem;

    public bool KillPlayer = false;


    private void Start()
    {
        currentHealth = health;
        maxHealth = health;
    }

    private void Update()
    {
        if (currentHealth != health)
        {
            currentHealth = health;
        }

        if (currentHealth <= 0)
        {
            //Game Over.
        }

        killMobFromEditor();
    }

    void killMobFromEditor()
    {
        if (KillPlayer)
        {
            health -= health;
            KillPlayer = false;
        }
    }
}

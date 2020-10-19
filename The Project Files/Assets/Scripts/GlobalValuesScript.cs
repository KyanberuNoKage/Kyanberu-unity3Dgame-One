using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GlobalValuesScript : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public Image healthBar;
    public GameObject Player;
    private string Score;
    private float healthBarHealth;

    public GameObject GameWinScreen;
    public GameObject overlay;
    public GameObject PauseScreen;
    private bool disableScriptsRunOnce = false;

    private bool pauseMenuActive = false;

    // Update is called once per frame
    void Update()
    {
        ScoreToScreen();

        HealthToScreen();

        PauseMenu();

        if (score >= 100 && disableScriptsRunOnce == false)
        {
            enableWinScreen();

            disablePlayer();

            disableScriptsRunOnce = true;
        }
    }

    void PauseMenu()
    {
        if (Input.GetKeyUp(KeyCode.Tab) && !pauseMenuActive)
        {
            disablePlayer();
            overlay.SetActive(false);
            PauseScreen.GetComponent<Canvas>().enabled = true;
            pauseMenuActive = true;
        }
        else if (Input.GetKeyUp(KeyCode.Tab) && pauseMenuActive)
        {
            enablePlayer();
            overlay.SetActive(true);
            PauseScreen.GetComponent<Canvas>().enabled = false;
            pauseMenuActive = false;
        }
    }

    void ScoreToScreen()
    {
        if (score < 10)
        {
            Score = "  Score: " + score.ToString();
        }
        else if (score < 100)
        {
            Score = " Score: " + score.ToString();
        }
        else
        {
            Score = "Score: " + score.ToString();
        }

        scoreText.text = Score;
    }

    void HealthToScreen()
    {
        healthBarHealth = Player.GetComponent<PlayerHealth>().health / Player.GetComponent<PlayerHealth>().maxHealth;
        healthBar.fillAmount = healthBarHealth;

        if (healthBarHealth > 0.6f)
        {
            healthBar.color = Color.green;
        }
        else if (healthBarHealth > 0.35f)
        {
            healthBar.color = Color.yellow;
        }
        else
        {
            healthBar.color = Color.red;
        }
    }

    void disablePlayer()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.transform.Find("Player Camera").GetComponent<PlayerLookAround>().enabled = false;

        List<GameObject> gunsInHolster = Player.transform.Find("Player Camera").transform.Find("GunHolsterObject").GetComponent<PlayerGunSwap>().gunsInHolster;

        Player.transform.Find("Player Camera").transform.Find("GunHolsterObject").GetComponent<PlayerGunSwap>().enabled = false;

        foreach (GameObject gun in gunsInHolster)
        {
            Debug.Log(gun.name);

            gun.SetActive(false);
        }

        Cursor.lockState = CursorLockMode.Confined;
    }

    void enablePlayer()
    {
        Player.GetComponent<PlayerMovement>().enabled = true;
        Player.transform.Find("Player Camera").GetComponent<PlayerLookAround>().enabled = true;
        Player.transform.Find("Player Camera").transform.Find("GunHolsterObject").GetComponent<PlayerGunSwap>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void enableWinScreen()
    {
        overlay.SetActive(false);
        GameWinScreen.GetComponent<Canvas>().enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunSwap : MonoBehaviour
{
    /*Refrences To All The Guns*/
    public List<GameObject> gunsInHolster = new List<GameObject>();
    /*-------------------------*/

    public int ActiveGun = 0;
    private string scrollDirection;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject gun in gunsInHolster)
        {
            gun.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!gunsInHolster[ActiveGun].GetComponent<GunPickedUp>().isPickedUp)
        {
            gunsInHolster[ActiveGun].SetActive(false);

            switch (scrollDirection)
            {
                case "down":

                    if (ActiveGun != 0)
                    {
                        ActiveGun -= 1;
                    }
                    else
                    {
                        ActiveGun = gunsInHolster.Count - 1;
                    }
                    scrollDirection = "Not Scrolling";
                    break;

                case "up":

                    if (ActiveGun != gunsInHolster.Count - 1)
                    {
                        ActiveGun += 1;
                    }
                    else
                    {
                        ActiveGun = 0;
                    }
                    scrollDirection = "Not Scrolling";
                    break;
            }
        }
        else
        {
            gunsInHolster[ActiveGun].SetActive(true);
        }


        ScrollWheelDown();

        ScrollWheelUp();
    }

    void ScrollWheelDown()
    {
        if (Input.mouseScrollDelta == new Vector2(0, -1))
        {
            scrollDirection = "down";
            Debug.Log("Scrolled Down");

            gunsInHolster[ActiveGun].SetActive(false);

            if (ActiveGun > 0)
            {
                ActiveGun -= 1;
            }
            else
            {
                ActiveGun = gunsInHolster.Count - 1;
            }
        }
    }

    void ScrollWheelUp()
    {
        if (Input.mouseScrollDelta == new Vector2(0, 1))
        {
            scrollDirection = "up";
            Debug.Log("Scrolled Up");

            gunsInHolster[ActiveGun].SetActive(false);

            if (ActiveGun < gunsInHolster.Count - 1)
            {
                ActiveGun += 1;
            }
            else
            {
                ActiveGun = 0;
            }
        }
    }
}

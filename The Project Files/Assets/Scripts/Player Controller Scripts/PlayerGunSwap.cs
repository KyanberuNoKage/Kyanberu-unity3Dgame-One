using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunSwap : MonoBehaviour
{
    /*Refrences To All The Guns*/
    public List<GameObject> gunsInHolster = new List<GameObject>();
    /*-------------------------*/

    public int ActiveGun = 0;

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
        gunsInHolster[ActiveGun].SetActive(true);

        ScrollWheelDown();

        ScrollWheelUp();
    }

    void ScrollWheelDown()
    {
        if (Input.mouseScrollDelta == new Vector2(0, -1))
        {
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

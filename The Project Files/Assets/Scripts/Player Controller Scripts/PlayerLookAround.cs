using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLookAround : MonoBehaviour
{
    public float MouseSensitivity = 50;
    public Transform playerBody;

    private float xRotation;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
            float mouseX = Input.GetAxis("Mouse X") * MouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -80f, 50f);
            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);

            playerBody.Rotate(Vector3.up * mouseX);
    }

    public void MouseSensitivityChange()
    {
        MouseSensitivity = GameObject.Find("Pause Screen").transform.Find("Slider").GetComponent<Slider>().value;
        GameObject.Find("Pause Screen").transform.Find("Slider").transform.Find("Text").GetComponent<Text>().text = ((int)(MouseSensitivity/2)).ToString();
    }
}

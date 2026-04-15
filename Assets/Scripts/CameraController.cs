using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CameraController : MonoBehaviour
{

    public float mouseSensitivity = 10f;

    private float xRotation = 0f;
    private float yRotation = 0f;
    private Vector2 lookValue;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = lookValue.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //Debug.Log(mouseY);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookValue = context.ReadValue<Vector2>();
        //Debug.Log($"Look input On Camera= {lookValue}");
    }
}

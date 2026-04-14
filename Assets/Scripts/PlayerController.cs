using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction moveAction;
    InputAction jumpAction;
    InputAction lookAction;

    Rigidbody rb;
    public float speed = 10f;
    public float jumpHeight = 5f;
    public float mouseSensitivity = 10f;

    private Vector2 moveValue;

    private float xRotation = 0f;
    private Vector2 lookValue;
    private CharacterController controller;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //moving
        Vector3 move = (transform.right * moveValue.x) + (transform.forward * moveValue.y);
        controller.Move(move * speed * Time.deltaTime);

        //rotating/looking

        float mouseX = lookValue.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookValue.y * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation=Quaternion.Euler(xRotation, 0f, 0f);
        rb.transform.Rotate(Vector3.up * mouseX);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveValue = context.ReadValue<Vector2>();
        Debug.Log($"Move input = {moveValue}");
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookValue = context.ReadValue<Vector2>();
        Debug.Log($"Look input = {lookValue}");
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //rb.AddForce(new Vector3(0, 2, 0), ForceMode.Impulse);
        Debug.Log($"Jumping {context.performed} - Is Grounded: {controller.isGrounded}");
        if (context.performed && controller.isGrounded)
        {
            Debug.Log("We should jump");
            rb.AddForce(new Vector3(0,jumpHeight,0), ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        
    }
}

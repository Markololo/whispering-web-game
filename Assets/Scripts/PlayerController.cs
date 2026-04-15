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
    public float speed = 1f;
    public float jumpHeight = 5f;
    public float mouseSensitivity = 10f;
    public float groundCheckDistance = 1f;
    public LayerMask layerMask;
    private Vector2 moveValue;

    private float xRotation = 0f;
    private float yRotation = 0f;
    
    private Vector2 lookValue;

    public bool IsGrounded =>
    Physics.Raycast(transform.position + Vector3.up * 0.01f, Vector3.down, groundCheckDistance, layerMask);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.forward * moveValue.y);
        Vector3 move = (transform.right * moveValue.x) + (transform.forward * moveValue.y);
        //Debug.Log(move);
        rb.velocity = new Vector3(move.x * speed , rb.velocity.y, move.z * speed);
        //controller.Move(move * speed * Time.deltaTime);

        //rotating/looking

        float mouseX = lookValue.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookValue.y * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        transform.localRotation=Quaternion.Euler(0f, yRotation, 0f);
        rb.transform.Rotate(Vector3.up * mouseX);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveValue = context.ReadValue<Vector2>();
        //Debug.Log($"Move input = {moveValue}");
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookValue = context.ReadValue<Vector2>();
        //Debug.Log($"Look input = {lookValue}");
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log($"Jumping {context.performed} - Is Grounded: {IsGrounded}");
        if (context.performed && IsGrounded)
        {
            Debug.Log("We should jump");
            rb.AddForce(new Vector3(0,jumpHeight,0), ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        
    }
}

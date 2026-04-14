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

    private Vector2 moveValue;
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
        Vector3 move = new Vector3(moveValue.x, 0, moveValue.y);
        controller.Move(move * speed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveValue = context.ReadValue<Vector2>();
        Debug.Log($"Move input = {moveValue}");
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 lookValue = lookAction.ReadValue<Vector2>();
        transform.Rotate(Vector3.up * lookValue.x * Time.deltaTime);
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

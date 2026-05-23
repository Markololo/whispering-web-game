
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    InputAction moveAction;
    InputAction jumpAction;
    InputAction lookAction;

    Rigidbody rb;

    //* Movement Stats
    public float speed = 1f;
    public float jumpHeight = 5f;
    public float mouseSensitivity = 10f;
    public float groundCheckDistance = 1f;
    private Vector2 moveValue;

    //*item fields
    public GameObject pickaxe;
    // public Animator PickaxeAnimator;
    public GameObject helmet;
    public bool hasKey { get; set; }
    public bool hasPickAxe { get; set; }
    public bool hasHelmet { get; set; }


    //* Bait stuff
    public GameObject baitPrefab;
    public Transform baitSpawnPoint;
    public float baitMaxImpulse = 10.0f;
    public int baitAmount;
    public GameObject heldBait;

    // public Animator DoorAnimator;

    public LayerMask layerMask;

    //* Looking Stats
    private float xRotation = 90f;
    private float yRotation = 0f;

    private Vector2 lookValue;

    private AudioSource source;
    public AudioClip footsteps;
    //* Check for if the player is grounded, used for jumping mechanics
    public bool IsGrounded =>
    Physics.Raycast(transform.position + Vector3.up * 0.01f, Vector3.down, groundCheckDistance, layerMask);

    //* Game Over UI
    private GameOverMenu gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
        // pickaxe.SetActive(false);
        // helmet.SetActive(false);
        hasKey = false;
        gameOverUI = GetComponent<GameOverMenu>();
        baitAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.forward * moveValue.y);
        Vector3 move = (transform.right * moveValue.x) + (transform.forward * moveValue.y);
        //Debug.Log(move);
        rb.velocity = new Vector3(move.x * speed, rb.velocity.y, move.z * speed);
        //controller.Move(move * speed * Time.deltaTime);

        //rotating/looking

        float mouseX = lookValue.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookValue.y * mouseSensitivity * Time.deltaTime;

        yRotation += mouseX;
        transform.localRotation = Quaternion.Euler(0f, yRotation, 0f);
        rb.transform.Rotate(Vector3.up * mouseX);



        if (Input.GetMouseButtonUp(1))
        {
            if (baitAmount > 0)
            {
                baitAmount--;

                if (baitAmount < 0)
                {
                    baitAmount = 0;
                }
                ThrowBait();
            }
        }

        if (baitAmount > 0)
        {
            heldBait.SetActive(true);
        }
        else
        {
            heldBait.SetActive(false);
        }
    }

    void ThrowBait()
    {
        GameObject bait = Instantiate(baitPrefab, baitSpawnPoint.position, baitSpawnPoint.rotation);
        Rigidbody rb = bait.GetComponent<Rigidbody>();

        float baitImpulse = baitMaxImpulse;

        Debug.Log($"Throwing ${baitImpulse}");

        // An Impulse is a force you apply on a object in a single instant. 
        rb.AddForce(baitSpawnPoint.forward * baitImpulse, ForceMode.Impulse);
    }

    //* Unity Input System functions
    public void OnMove(InputAction.CallbackContext context)
    {
        source.clip = footsteps;
        source.Play();
        moveValue = context.ReadValue<Vector2>();
        //Debug.Log($"Move input = {moveValue}");
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookValue = context.ReadValue<Vector2>();
        //Debug.Log($"Look input = {lookValue}");
    }

    public AudioClip jump;
    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log($"Jumping {context.performed} - Is Grounded: {IsGrounded}");
        if (context.performed && IsGrounded)
        {
            Debug.Log("We should jump");
            source.PlayOneShot(jump);
            rb.AddForce(new Vector3(0, jumpHeight, 0), ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {

    }

    public AudioClip pickAxe;
    public AudioClip axeHit;
    public AudioClip pickHelmet;
    public AudioClip pickKey;
    public AudioClip destroyBox;
    public AudioClip openDoor;
    public AudioClip doorClosed;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Pickaxe")
        {
            pickaxe.SetActive(true);
            source.clip = pickAxe;
            source.PlayOneShot(pickAxe);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Helmet")
        {
            helmet.SetActive(true);
            source.clip = pickHelmet;
            source.PlayOneShot(pickHelmet);
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == "Breakable")
        {
            // PickaxeAnimator.SetTrigger("Swing");
            // source.clip = axeHit;
            // source.PlayOneShot(axeHit);
            // source.clip = destroyBox;
            // source.PlayOneShot(destroyBox);
            // other.gameObject.SetActive(false);
            if (Input.GetMouseButton(0) && pickaxe.activeSelf)
            {
                Debug.Log("Hit a breakable");
                Breakable target = other.gameObject.GetComponent<Breakable>();

                if (target != null)
                {
                    Debug.Log("Breaking");
                    target.Break();
                }
            }
            hasKey = true;
        }

        if (other.gameObject.tag == "Walls")
        {

            source.clip = doorClosed;
            source.PlayOneShot(doorClosed);

        }

        if (other.gameObject.tag == "Spider")
        {
            StartCoroutine(DelayedGameOver(3f)); // wait 3 secs to see the attack at least
            // SceneManager.LoadScene("GameOver");
            // gameOverUI.GameOver();
        }

        if (other.gameObject.tag == "Bait")
        {
            Destroy(other.gameObject);
            baitAmount++;
        }
    }

    //coroutine to wait a few secs before dying to see spider attack anim
    private IEnumerator DelayedGameOver(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameOverUI.GameOver();
    }
}

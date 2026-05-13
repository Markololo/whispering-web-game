using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickaxeContoller : MonoBehaviour
{
    public bool isActive;
    public bool isSwinging;
    public Animator animator;
    public BoxCollider collider;
    public AudioClip axeHit;
    // public AudioSource source;

    public GameObject tryingToCollide;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.collider = GetComponent<BoxCollider>();
        // this.source = GetComponent<AudioSource>();
        // tryingToCollide = GetComponent<>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("isSwinging", true);
            collider.enabled = true;
            // source.clip = axeHit;
            // source.PlayOneShot(axeHit);
            // tryingToCollide.enabled = true;
        }
        else
        {
            animator.SetBool("isSwinging", false);
            // collider.enabled = false;
            // tryingToCollide.enabled = false;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("We Collisioning");
        if (other.gameObject.tag == "Breakable")
        {
            Debug.Log("Hit a breakable");
            Breakable target = other.gameObject.GetComponent<Breakable>();

            if (target != null)
            {
                target.Break();
            }
        }

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Touching the player");
        }
    }

    private void OnTriggerEnter(Collider other) {
        
    }
}

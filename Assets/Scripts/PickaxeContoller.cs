using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickaxeContoller : MonoBehaviour
{
    private bool isActive;
    private bool isSwinging;
    private Animator animator;
    private BoxCollider collider;
    public AudioClip axeHit;
    private AudioSource source;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isSwinging", true);
            collider.enabled = true;
            source.clip = axeHit;
            source.PlayOneShot(axeHit);
        }
        else
        {
            animator.SetBool("isSwinging", false);
            collider.enabled = true;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
    }

    private void OnCollisionEnter(Collider other)
    {
        // if (other.gameObject.tag == "Breakable")
        // {
        //     other.gameObject.SetActive(false);
        // }
    }
}

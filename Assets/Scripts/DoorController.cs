using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // public GameObject player;
    public Animator doorAnimator;

    public PlayerController playerController;

    private bool playerHasKey;
    // Start is called before the first frame update
    void Start()
    {
        playerHasKey = playerController.hasKey;

    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(playerHasKey);
    }

    // void OnCollisionEnter(Collision other)
    // {
    //     playerHasKey = playerController.hasKey;
    //     if (other.gameObject.tag == "Player")
    //     {
    //         Debug.Log("Player touched the door");
    //         Debug.Log(playerHasKey);
    //         if (playerHasKey)
    //         {
    //             Debug.Log("Player has the key");
    //             doorAnimator.SetTrigger("Open");
    //             // source.clip = openDoor;
    //             // source.PlayOneShot(openDoor);s
    //             playerController.hasKey = false;
    //             //play open door sound here
    //         }
    //         else
    //         {
    //             // source.clip = doorClosed;
    //             // source.PlayOneShot(doorClosed);
    //             // play locked door sound here
    //         }
    //     }
    // }

    private void OnTriggerEnter(Collider other)
    {
        playerHasKey = playerController.hasKey;
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player touched the door");
            if (PlayerItems.hasKey)
            {
                doorAnimator.SetTrigger("Open");
                // source.clip = openDoor;
                // source.PlayOneShot(openDoor);s
                PlayerItems.hasKey = false;
                //play open door sound here
            }
            else
            {
                // source.clip = doorClosed;
                // source.PlayOneShot(doorClosed);
                // play locked door sound here
            }
        }
    }
}

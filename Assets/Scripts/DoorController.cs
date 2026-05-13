using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    // public GameObject player;
    public Animator doorAnimator;

    // public PlayerController playerController;
    private GameObject player;

    private bool playerHasKey;
    // Start is called before the first frame update
    private PlayerController playerController;
    void Start()
    {
        // playerHasKey = playerController.hasKey;
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        // Debug.Log(player.name);
    }

    // Update is called once per frame
    void Update()
    {
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
            if (playerHasKey)
            {
                doorAnimator.SetTrigger("Open");
                // source.clip = openDoor;
                // source.PlayOneShot(openDoor);
                playerHasKey = false;
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBumps : MonoBehaviour
{
    private AudioSource source;
    public AudioClip playerBump;    

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") //Change to player tag
        {
            source.clip = playerBump;
            source.PlayOneShot(playerBump);

        }
    }
}

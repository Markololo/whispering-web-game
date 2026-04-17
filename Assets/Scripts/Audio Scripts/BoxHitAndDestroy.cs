using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHitAndDestroy : MonoBehaviour
{
    private AudioSource source;
    public AudioClip clip1;
    public AudioClip clip2;

    public AudioClip playerBump;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift)) //Change to player attack input and remove the or just for testing
        {
            source.clip = clip1;
            source.PlayOneShot(clip1);
            source.clip = clip2;
            source.PlayOneShot(clip2);
            //Destroy(gameObject); IDK if it goes away or is just scattered
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Axe" ) //Change to item tag and remove if we are doing it based on player like the secon one
        {
            source.clip = clip1;
            source.PlayOneShot(clip1);
            source.clip = clip2;
            source.PlayOneShot(clip2);
            //Destroy(gameObject); IDK if it goes away or is just scattered
        }

        if(collision.gameObject.tag == "Player") //Change to player tag
        {
            source.clip = playerBump;
            source.PlayOneShot(playerBump);
           
        }
    }
}

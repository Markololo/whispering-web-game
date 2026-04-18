using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxePickup : MonoBehaviour
{
    private AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (source != null)
        {
            clip = source.clip;
        }

        if (Input.GetKeyUp(KeyCode.RightShift)) //Change to command that makes player pick things up
        { //Change this to the pick up control set
            source.PlayOneShot(clip);
        }
    }

   
}

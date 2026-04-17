using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightClick : MonoBehaviour
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
        if (source != null) {
            clip = source.clip;
        }

        if (Input.GetKeyUp(KeyCode.Space)) { //Change this to the pick up control set
                source.PlayOneShot(clip);
        }
    }
}

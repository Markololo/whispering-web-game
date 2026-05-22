using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPad : MonoBehaviour
{
    private AudioSource source;
    public AudioClip clip;
     void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void PlayBeep()
    {
        source.clip = clip;
        source.PlayOneShot(clip);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}

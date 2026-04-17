using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExitAudio : MonoBehaviour
{
    private AudioSource source;
    public AudioClip clip1;
    public AudioClip clip2;

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
            source.clip = clip1;
            source.loop = true;
            source.volume = 0.8f;
            source.Play();
        }

        void OnCollisionEnter(Collision collision)
        {


            if (collision.gameObject.tag == "Player") //Change to player tag
            {
                source.clip = clip1;
                source.PlayOneShot(clip1);
                source.clip = clip2;
                source.PlayOneShot(clip2);

            }
        }
    }
}

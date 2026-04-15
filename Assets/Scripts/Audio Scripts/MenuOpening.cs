using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOpening : MonoBehaviour
{
    public AudioClip loadSound;
    public AudioClip loopSound;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        //source.clip = sound;
        //source.Play();
        StartCoroutine(PlayLoadLoop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PlayLoadLoop()
    {
        source.clip = loadSound;
        source.loop = false;
        source.Play();

        yield return new WaitForSeconds(loadSound.length);
        source.clip = loopSound;
        source.loop = true;
        source.Play();
    }

    public void StopMusic()
    {
        StopAllCoroutines(); //In case player clicks immediately before it finishes loading
        source.Stop();
    }
}

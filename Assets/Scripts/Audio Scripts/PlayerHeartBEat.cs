using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeartBEat : MonoBehaviour
{
    private AudioSource source;
    public AudioClip heartBeat;
    public float interval = 10f;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(PlayerHeartBeat());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator PlayerHeartBeat()
    {
        source.clip = heartBeat;
        source.PlayOneShot(heartBeat);
        yield return new WaitForSeconds(interval);
        source.Stop();
    }
}

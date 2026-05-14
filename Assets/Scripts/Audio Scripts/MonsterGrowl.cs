using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGrowl : MonoBehaviour
{
    private AudioSource source;
    public AudioClip audioClip;
    public float waitTime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(MonsterGrowlPeriodically());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator MonsterGrowlPeriodically()
    {
        yield return new WaitForSeconds(waitTime);
        {
            source.clip = audioClip;
            source.PlayOneShot(audioClip);
        }
    }
}

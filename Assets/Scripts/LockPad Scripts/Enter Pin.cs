using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterPin : MonoBehaviour
{
    public string pinCode; // i put it public so you guys can change it whenever but if it messes with the build we can make it private;
    public Text pinEntered;
    private AudioSource source;
    public AudioClip wrongPin;
    public AudioClip rightPin;

    public GameObject door;
    public Animator doorAnimator;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        doorAnimator = door.GetComponent<Animator>();
    }
    public void CheckPinMatch()
    {
        string inputEntered = pinEntered.text.Trim();

        if (inputEntered.Length != pinCode.Length)
        {
            Debug.Log("Pin does not match. Try again.");
            source.PlayOneShot(wrongPin);


        }
        if (inputEntered == pinCode)
        {
            Debug.Log("Pin Matched!");
            doorAnimator.SetTrigger("Open");
            source.PlayOneShot(rightPin);
        }
        else
        {
            Debug.Log("Pin does not match. Try again.");
            source.PlayOneShot(wrongPin);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

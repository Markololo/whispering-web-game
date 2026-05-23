using System.Collections;
using UnityEngine;

public class KeypadMessage : MonoBehaviour
{
    public GameObject messageUI; // drag your UI text here
    public float displayTime = 3f;

    private bool hasShown = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasShown)
        {
            hasShown = true;
            StartCoroutine(ShowMessage());
        }
    }

    IEnumerator ShowMessage()
    {
        messageUI.SetActive(true);

        yield return new WaitForSeconds(displayTime);

        messageUI.SetActive(false);
    }
}
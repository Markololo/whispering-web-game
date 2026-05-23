using System.Collections;
using UnityEngine;

public class RiddleTrigger : MonoBehaviour
{
    public GameObject riddleTextObject;
    public float displayDuration = 10f;
    public bool triggerOnce = true;//so it doesn't re-show if player walks back in

    private bool hasTriggered = false;

    private void Start()
    {
        //text hidden at the start
        if (riddleTextObject != null)
            riddleTextObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (triggerOnce && hasTriggered) return;

        hasTriggered = true;
        StartCoroutine(ShowRiddle());
    }

    private IEnumerator ShowRiddle()
    {
        riddleTextObject.SetActive(true);
        yield return new WaitForSeconds(displayDuration);
        riddleTextObject.SetActive(false);
    }
}
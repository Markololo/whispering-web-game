using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RulesTextController : MonoBehaviour
{
    public Text rulesText;
    public float displayTime = 10f;
    public float flashInterval = 0.5f;

    void Start()
    {
        StartCoroutine(ShowRules());
    }

    IEnumerator ShowRules()
    {
        float timer = 0f;

        while (timer < displayTime)
        {
            rulesText.enabled = !rulesText.enabled;

            yield return new WaitForSeconds(flashInterval);
            timer += flashInterval;
        }

        rulesText.enabled = false;
    }
}
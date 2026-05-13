using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RulesTextController : MonoBehaviour
{
    public Text rulesText;
    public float displayTime = 10f;
    public float fadeDuration = 2f;

    void Start()
    {
        StartCoroutine(ShowRules());
    }

    IEnumerator ShowRules()
    {


        yield return new WaitForSeconds(displayTime);

        Debug.Log("Fading Text");
        Color originalColor = rulesText.color;

        float timer = 0f;

        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);

            rulesText.color = new Color(
                originalColor.r,
                originalColor.g,
                originalColor.b,
                alpha
            );

            timer += Time.deltaTime;
            yield return null;
        }

        rulesText.color = new Color(
            originalColor.r,
            originalColor.g,
            originalColor.b,
            0f
        );

    }
}
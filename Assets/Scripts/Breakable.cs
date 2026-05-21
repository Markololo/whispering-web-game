using System.Collections;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public float explosionForce = 400f;
    public float upwardModifier = 1.5f;
    public float explosionRadius = 2f;
    public float chunkLifetime = 1.0f;

    public Light glowLight;

    public float normalLightIntensity = 1f;
    public float boomLightMin = 6f;
    public float boomLightMax = 10f;

    public float shakeDuration = 0.5f;
    public float shakeAmount = 0.08f;

    private bool broken = false;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;

        if (glowLight != null)
        {
            glowLight.intensity = normalLightIntensity;
        }
    }

    public void Break()
    {
        if (broken) return;
        broken = true;

        StartCoroutine(BreakSequence());
    }

    IEnumerator BreakSequence()
    {
        Animator animator = GetComponent<Animator>();

        if (animator != null)
        {
            animator.SetTrigger("Break");
        }

        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            transform.position = originalPosition + Random.insideUnitSphere * shakeAmount;

            if (glowLight != null)
            {
                glowLight.intensity = Random.Range(boomLightMin, boomLightMax);
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPosition;

        if (glowLight != null)
        {
            glowLight.intensity = boomLightMax;
        }

        yield return new WaitForSeconds(1f);

        Destroy(gameObject);
    }
}
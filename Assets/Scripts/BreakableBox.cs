using UnityEngine;
using System.Collections;

public class BreakableBox : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private AudioSource source;

    public AudioClip hitSound;
    public AudioClip destroySound;

    public GameObject breakParticles;

    public Light glowLight;

    private Vector3 originalPosition;

    private bool isBreaking = false;

    private void Start()
    {
        source = GetComponent<AudioSource>();

        currentHealth = maxHealth;

        originalPosition = transform.position;
    }

    public void TakeHit()
    {
        if (isBreaking) return;

        currentHealth--;

        source.PlayOneShot(hitSound);

        Debug.Log("Box health: " + currentHealth + "/" + maxHealth);

        if (currentHealth <= 0)
        {
            StartCoroutine(BreakSequence());
        }
    }

    IEnumerator BreakSequence()
    {
        isBreaking = true;

        float duration = 0.5f;

        float elapsed = 0f;

        while (elapsed < duration)
        {
            // SHAKE
            transform.position = originalPosition +
                Random.insideUnitSphere * 0.08f;

            // LIGHT FLICKER
            if (glowLight != null)
            {
                glowLight.intensity = Random.Range(6f, 10f);
            }

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.position = originalPosition;

        // EXPLOSION PARTICLES
        Instantiate(breakParticles, transform.position, Quaternion.identity);

        // DESTROY SOUND
        source.PlayOneShot(destroySound);

        Destroy(gameObject);
    }
}
using UnityEngine;

public class BreakableBox : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;


    private AudioSource source;
    public AudioClip hitSound;
    public AudioClip destroySound;


    private void Start()
    {
        source = GetComponent<AudioSource>();
        currentHealth = maxHealth;
    }

    public void TakeHit()
    {
        currentHealth--;
        source.clip = hitSound;
        source.PlayOneShot(hitSound); 
        Debug.Log("Box health: " + currentHealth + "/" + maxHealth);
        
        if (currentHealth <= 0)
        {
            source.clip = destroySound;
            source.PlayOneShot(destroySound); 
            Destroy(gameObject);
        }
    }
}
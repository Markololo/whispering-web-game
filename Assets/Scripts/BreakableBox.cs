using UnityEngine;

public class BreakableBox : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeHit()
    {
        currentHealth--;
        Debug.Log("Box health: " + currentHealth + "/" + maxHealth);

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
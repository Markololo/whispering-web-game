using UnityEngine;

public class BreakableBox : MonoBehaviour
{
    public void Break()
    {
        Destroy(gameObject);
    }
}
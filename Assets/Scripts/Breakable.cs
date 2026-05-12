using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public float explosionForce = 400f;
    public float upwardModifier = 1.5f;
    public float explosionRadius = 2f;
    public float chunkLifetime = 1.0f;

    private bool broken = false;

    public void Break(Vector3 hitPosition)
    {
        if (broken) return;
        broken = true;
        // we find this to
        Vector3 explosionOrigin = transform.position - hitPosition.normalized * 0.5f;

        foreach (Transform child in transform)
        {
            Rigidbody rb = child.GetComponent<Rigidbody>();
            if (rb == null) continue;

            child.SetParent(null);
            rb.isKinematic = false;
            rb.AddExplosionForce(explosionForce, explosionOrigin, explosionRadius, upwardModifier, ForceMode.Impulse);


            if (chunkLifetime > 0f)
                Destroy(child.gameObject, chunkLifetime);
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("We Collisioning");
        if (other.gameObject.tag == "pickaxe")
        {
            Debug.Log("Hit a breakable");
            Breakable target = other.gameObject.GetComponent<Breakable>();

            if (target != null)
            {
                target.Break(other.contacts[0].point);
            }
        }
    }
}

using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string itemName = "Item";

    public Vector3 heldLocalPosition = new Vector3(0.3f, -0.2f, 0.8f);
    public Vector3 heldLocalRotation = Vector3.zero;

    public AudioClip dropItem;
    public AudioClip pickItem;

    //* The items that are going to be equipped/enabled on the player
    public GameObject pickaxe;
    public GameObject helmet;
    public GameObject player;
    private AudioSource source;
    private Rigidbody rb;
    private Collider col;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        source = GetComponent<AudioSource>();
    }

    public void PickUp()
    {
        // if (rb != null)
        // {
        //     rb.isKinematic = true;
        //     rb.useGravity = false;
        //     rb.velocity = Vector3.zero;
        //     rb.angularVelocity = Vector3.zero;
        // }

        // if (col != null)
        // {
        //     col.enabled = false;
        // }

        // transform.SetParent(holdPoint);
        // transform.localPosition = heldLocalPosition;
        // transform.localRotation = Quaternion.Euler(heldLocalRotation);

        // source.clip = pickItem;
        // source.PlayOneShot(pickItem);
        // return gameObject;
        pickaxe.SetActive(true);
    }

    public void Drop(Vector3 dropPosition)
    {
        transform.SetParent(null);
        transform.position = dropPosition;
        source.clip = dropItem;
        source.PlayOneShot(dropItem);

        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }

        if (col != null)
        {
            col.enabled = true;
        }
    }
}
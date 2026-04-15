using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickup : MonoBehaviour
{
    public Transform holdPoint;
    public float pickupRange = 3f;

    private GameObject heldItem;

public void OnInteract(InputValue value)
{
    Debug.Log("Interact pressed");

    Camera cam = GetComponent<Camera>();
    if (cam == null)
    {
        Debug.LogWarning("No Camera found on Player.");
        return;
    }

    Ray ray = new Ray(cam.transform.position, cam.transform.forward);
    RaycastHit hit;

    if (Physics.Raycast(ray, out hit, pickupRange))
    {
        // PICKUP
        PickupItem pickup = hit.collider.GetComponent<PickupItem>();
        if (pickup != null && heldItem == null)
        {
            heldItem = pickup.PickUp(holdPoint);
            Debug.Log("Picked up: " + pickup.itemName);
            return;
        }

        // BREAK BOX
        BreakableBox box = hit.collider.GetComponent<BreakableBox>();
        if (box != null && heldItem != null)
        {
            PickupItem heldPickup = heldItem.GetComponent<PickupItem>();
            if (heldPickup != null && heldPickup.itemName == "Axe")
            {
                box.Break();
                Debug.Log("Box broken!");
            }
        }
    }
}
}
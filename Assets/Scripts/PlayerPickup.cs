using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerPickup : MonoBehaviour
{
    public Camera playerCamera;
    public Transform holdPoint;
    public float pickupRange = 5f;
    public float hitRange = 2.5f;

    private GameObject heldItem;
    private bool isAttacking = false;

    public void OnInteract(InputValue value)
    {
        Debug.Log("Interact pressed");

        if (playerCamera == null)
        {
            Debug.LogWarning("Player Camera is not assigned in PlayerPickup.");
            return;
        }

        Vector3 direction = playerCamera.transform.forward + Vector3.down * 0.5f;
        Ray ray = new Ray(playerCamera.transform.position, direction.normalized);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.3f, out hit, pickupRange))
        {
            Debug.Log("Hit object: " + hit.collider.gameObject.name);

            PickupItem pickup = hit.collider.GetComponentInParent<PickupItem>();
            if (pickup != null)
            {
                if (heldItem != null)
                {
                    PickupItem oldItem = heldItem.GetComponent<PickupItem>();
                    if (oldItem != null)
                    {
                        Vector3 dropPos = playerCamera.transform.position + playerCamera.transform.forward * 1.2f;
                        oldItem.Drop(dropPos);
                    }
                }

                heldItem = pickup.PickUp(holdPoint);
                Debug.Log("Picked up: " + pickup.itemName);
            }
        }
        else
        {
            Debug.Log("Nothing hit");
        }
    }

    public void OnAttack(InputValue value)
    {
        Debug.Log("Attack pressed");

        if (isAttacking) return;
        if (heldItem == null) return;

        PickupItem heldPickup = heldItem.GetComponent<PickupItem>();
        if (heldPickup == null) return;
        if (heldPickup.itemName != "Axe") return;

        StartCoroutine(AxeSwing());
    }

    private IEnumerator AxeSwing()
    {
        isAttacking = true;

        Vector3 startPos = heldItem.transform.localPosition;
        Quaternion startRot = heldItem.transform.localRotation;

        Vector3 attackPos = startPos + new Vector3(0.2f, -0.2f, 0.2f);
        Quaternion attackRot = startRot * Quaternion.Euler(0f, 0f, -70f);

        float time = 0f;
        float duration = 0.12f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            heldItem.transform.localPosition = Vector3.Lerp(startPos, attackPos, t);
            heldItem.transform.localRotation = Quaternion.Lerp(startRot, attackRot, t);

            yield return null;
        }

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.4f, out hit, hitRange))
        {
            BreakableBox box = hit.collider.GetComponentInParent<BreakableBox>();
            if (box != null)
            {
                box.TakeHit();
                Debug.Log("Axe hit box");
            }
        }

        time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            heldItem.transform.localPosition = Vector3.Lerp(attackPos, startPos, t);
            heldItem.transform.localRotation = Quaternion.Lerp(attackRot, startRot, t);

            yield return null;
        }

        heldItem.transform.localPosition = startPos;
        heldItem.transform.localRotation = startRot;

        isAttacking = false;
    }
}
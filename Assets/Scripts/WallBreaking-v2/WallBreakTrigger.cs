using System.Collections;
using UnityEngine;

public class WallBreakTrigger : MonoBehaviour
{
    public int hitsToBreak = 3;
    // public string wallRocksFolderName = "wall-rocks";
    public GameObject wallRocksFolder;
    public AudioClip hitSound;
    public AudioClip breakSound;

    private int hitCount = 0;
    private bool broken = false;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    //Called by PickaxeContoller from the tag Breakable
    public void Break()
    {
        if (broken) return;

        hitCount++;
        Debug.Log($"Wall hit {hitCount}/{hitsToBreak}");

        if (source != null && hitSound != null)
            source.PlayOneShot(hitSound);

        if (hitCount >= hitsToBreak)
        {
            broken = true;
            BreakWall();
        }
    }

    private void BreakWall()
    {
        // GameObject wallRocksFolder = GameObject.Find(wallRocksFolderName);

        if (wallRocksFolder != null)
        {
            foreach (Rigidbody rb in wallRocksFolder.GetComponentsInChildren<Rigidbody>())
                rb.isKinematic = false;

            //cleanup
            WallRocksFader fader = wallRocksFolder.GetComponent<WallRocksFader>();
            if (fader != null) fader.ScheduleCleanup();
        }
        else
        {
            Debug.LogWarning("No wall rocks folder assigned!");
        }

        if (source != null && breakSound != null)
        {
            source.PlayOneShot(breakSound);
            Destroy(gameObject, breakSound.length); //wait for sound to finish
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
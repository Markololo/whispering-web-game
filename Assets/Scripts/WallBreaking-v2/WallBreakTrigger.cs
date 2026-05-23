using UnityEngine;

public class WallBreakTrigger : MonoBehaviour
{
    public int hitsToBreak = 3;
    // public string wallRocksFolderName = "wall-rocks";
    public GameObject wallRocksFolder;
    private int hitCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        hitCount++;
        Debug.Log($"Wall hit {hitCount}/{hitsToBreak}");

        if (hitCount >= hitsToBreak)
            BreakWall();
    }

    private void BreakWall()
    {
        // Find the wall-rocks parent GameObject by name
        // GameObject wallRocksFolder = GameObject.Find(wallRocksFolderName);

        if (wallRocksFolder != null)
        {
            // Un-kinematic every Rigidbody in the folder so they fall
            foreach (Rigidbody rb in wallRocksFolder.GetComponentsInChildren<Rigidbody>())
            {
                rb.isKinematic = false;
            }
            WallRocksFader fader = wallRocksFolder.GetComponent<WallRocksFader>();
            if (fader != null) fader.ScheduleCleanup();
        }
        else
        {
            Debug.LogWarning($"Could not find GameObject folder");
        }

        Destroy(gameObject);
    }
}
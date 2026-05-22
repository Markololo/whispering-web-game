using UnityEngine;

public class WallBreakTrigger : MonoBehaviour
{
    // will change the hits to break to use the pickaxe

    public int hitsToBreak = 3;
    public string wallRocksFolderName = "wall-rocks";
    private int hitCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        hitCount++;
        // Debug.Log($"Wall hit {hitCount}/{hitsToBreak}");

        if (hitCount >= hitsToBreak)
            BreakWall();
    }

    private void BreakWall()
    {
        //find the wall-rocks parent 
        GameObject wallRocksFolder = GameObject.Find(wallRocksFolderName);

        if (wallRocksFolder != null)
        {
            //un-kinematic every rock in the folder so they fall
            foreach (Rigidbody rb in wallRocksFolder.GetComponentsInChildren<Rigidbody>())
            {
                rb.isKinematic = false;
            }
            WallRocksFader fader = wallRocksFolder.GetComponent<WallRocksFader>();
            if (fader != null) fader.ScheduleCleanup();
        }
        else
        {
            Debug.LogWarning($"Could not find GameObject '{wallRocksFolderName}'");
        }

        Destroy(gameObject);
    }
}
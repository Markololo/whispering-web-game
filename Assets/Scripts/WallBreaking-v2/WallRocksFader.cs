using UnityEngine;
using System.Collections;

//* TO make the rocks disapear after break to clean the scene
public class WallRocksFader : MonoBehaviour
{
    public float destroyDelay = 4f;

    // Called by WallBreakTrigger
    public void ScheduleCleanup()
    {
        StartCoroutine(CleanupAfterDelay());
    }

    private IEnumerator CleanupAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}
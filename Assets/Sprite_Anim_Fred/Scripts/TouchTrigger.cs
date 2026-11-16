using UnityEngine;

// Put this on traps or the goal object.
// When the player touches it, the level restarts or the player wins.
public class TouchTrigger : MonoBehaviour
{
    public enum Action { RestartLevel, Win }

    public Action onTouch = Action.RestartLevel;
    public string playerTag = "Player";

    void OnTriggerEnter2D(Collider2D other)
    {
        Check(other);
    }

    void OnCollisionEnter2D(Collision2D hit)
    {
        Check(hit.collider);
    }

    void Check(Collider2D col)
    {
        bool isPlayer = col.CompareTag(playerTag);

        // the collider can be on a child object, so also check the rigidbody
        if (!isPlayer && col.attachedRigidbody != null)
            isPlayer = col.attachedRigidbody.CompareTag(playerTag);

        if (!isPlayer) return;

        LevelFlow flow = FindFirstObjectByType<LevelFlow>();
        if (flow == null)
        {
            Debug.LogWarning("No LevelFlow object in the scene.");
            return;
        }

        if (onTouch == Action.Win)
            flow.Win();
        else
            flow.Restart();
    }
}

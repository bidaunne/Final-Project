using UnityEngine;
using UnityEngine.SceneManagement;

// Put this on an object with a Collider2D.
// When the player touches it, the chosen scene is loaded.
public class LoadSceneOnTouch : MonoBehaviour
{
    [Tooltip("Exact scene name (it must be in File > Build Profiles > Scene List)")]
    public string sceneName;

    public string playerTag = "Player";

    bool loading;

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
        if (loading) return;

        bool isPlayer = col.CompareTag(playerTag);

        // the collider can be on a child object, so also check the rigidbody
        if (!isPlayer && col.attachedRigidbody != null)
            isPlayer = col.attachedRigidbody.CompareTag(playerTag);

        if (!isPlayer) return;

        loading = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }
}

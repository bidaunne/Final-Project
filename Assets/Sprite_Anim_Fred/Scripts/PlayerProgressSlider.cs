using UnityEngine;
using UnityEngine.UI;

// Shows how far the player has moved on the X axis using a slider.
// The slider is empty at startX and full at endX.
[ExecuteAlways]
public class PlayerProgressSlider : MonoBehaviour
{
    public Transform player;
    public Slider progressSlider;

    [Tooltip("Player X position where the slider is empty")]
    public float startX = 100f;

    [Tooltip("Player X position where the slider is full")]
    public float endX = 1000f;

    void OnEnable()
    {
        if (progressSlider != null)
        {
            progressSlider.minValue = 0f;
            progressSlider.maxValue = 1f;
        }
    }

    void LateUpdate()
    {
        if (player == null || progressSlider == null) return;

        // 0 at startX, 1 at endX, clamped so it never goes outside the slider
        progressSlider.value = Mathf.InverseLerp(startX, endX, player.position.x);
    }
}

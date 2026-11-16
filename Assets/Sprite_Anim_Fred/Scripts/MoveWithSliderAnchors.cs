using UnityEngine;
using UnityEngine.UI;

// Moves a UI object on the Y axis by changing its anchors,
// so the position is a percentage of the parent (screen) height.
// Works the same on every screen resolution.
[ExecuteAlways]
[RequireComponent(typeof(RectTransform))]
public class MoveWithSliderAnchors : MonoBehaviour
{
    public Slider timeSlider;

    [Tooltip("Height in percent when the slider is at its start (0 = bottom, 100 = top)")]
    [Range(0f, 100f)]
    public float startPercent = 60f;

    [Tooltip("Height in percent when the slider is at its end")]
    [Range(0f, 100f)]
    public float endPercent = 40f;

    RectTransform rect;

    void LateUpdate()
    {
        if (timeSlider == null) return;
        if (rect == null) rect = GetComponent<RectTransform>();

        float percent = Mathf.Lerp(startPercent, endPercent, timeSlider.normalizedValue);
        float y = percent / 100f;

        // keep the distance between min and max anchors (in case the object is stretched)
        float gap = rect.anchorMax.y - rect.anchorMin.y;

        Vector2 min = rect.anchorMin;
        Vector2 max = rect.anchorMax;
        min.y = y;
        max.y = y + gap;

        rect.anchorMin = min;
        rect.anchorMax = max;
    }
}

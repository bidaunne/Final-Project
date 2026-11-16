using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

// Changes the Global Light 2D color while the time slider moves:
// start color -> red color (at redPoint) -> end color.
[ExecuteAlways]
public class SunLight : MonoBehaviour
{
    [Header("References")]
    public Slider timeSlider;
    public Light2D globalLight;

    [Header("Colors")]
    public Color startColor = Color.white;
    public Color redColor = new Color(1f, 0.35f, 0.2f);
    public Color endColor = new Color(0.25f, 0.35f, 0.9f);

    [Header("Timing")]
    [Range(0.05f, 0.95f)]
    [Tooltip("Where on the slider the light is fully red (0 = start, 1 = end)")]
    public float redPoint = 0.5f;

    void LateUpdate()
    {
        if (timeSlider == null || globalLight == null) return;

        float t = timeSlider.normalizedValue;

        if (t < redPoint)
        {
            // first half: start color to red
            globalLight.color = Color.Lerp(startColor, redColor, t / redPoint);
        }
        else
        {
            // second half: red to end color
            globalLight.color = Color.Lerp(redColor, endColor, (t - redPoint) / (1f - redPoint));
        }
    }
}

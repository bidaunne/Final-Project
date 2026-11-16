using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Fills the time slider. If time runs out you lose,
// if the goal is touched before that you win.
public class LevelFlow : MonoBehaviour
{
    [Header("Timer")]
    public Slider timeSlider;
    public float duration = 30f;

    [Header("Screens (keep them off in the scene)")]
    public GameObject winPanel;
    public GameObject losePanel;

    float timer;
    bool finished;

    void Start()
    {
        Time.timeScale = 1f;

        if (winPanel != null) winPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);

        if (timeSlider != null)
        {
            timeSlider.minValue = 0f;
            timeSlider.maxValue = 1f;
            timeSlider.value = 0f;
        }
    }

    void Update()
    {
        if (finished) return;

        timer += Time.deltaTime;

        if (timeSlider != null)
            timeSlider.value = Mathf.Clamp01(timer / duration);

        if (timer >= duration)
            Lose();
    }

    public void Win()
    {
        if (finished) return;
        finished = true;

        if (winPanel != null) winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Lose()
    {
        if (finished) return;
        finished = true;

        if (losePanel != null) losePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // Hook this to the restart buttons (OnClick)
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

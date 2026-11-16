using UnityEngine;
using UnityEngine.SceneManagement;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

// Loads a scene when any key or mouse button is pressed.
// Works with both the old and the new Input System.
public class LoadSceneOnAnyKey : MonoBehaviour
{
    [Tooltip("Exact scene name (it must be in File > Build Profiles > Scene List)")]
    public string sceneName;

    bool loading;

    void Update()
    {
        if (loading) return;

        if (AnyInputPressed())
        {
            loading = true;
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneName);
        }
    }

    bool AnyInputPressed()
    {
#if ENABLE_INPUT_SYSTEM
        Keyboard keyboard = Keyboard.current;
        Mouse mouse = Mouse.current;
        Touchscreen touch = Touchscreen.current;

        if (keyboard != null && keyboard.anyKey.wasPressedThisFrame) return true;

        if (mouse != null &&
            (mouse.leftButton.wasPressedThisFrame ||
             mouse.rightButton.wasPressedThisFrame ||
             mouse.middleButton.wasPressedThisFrame)) return true;

        if (touch != null && touch.primaryTouch.press.wasPressedThisFrame) return true;

        return false;
#else
        return Input.anyKeyDown;
#endif
    }
}

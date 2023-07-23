using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    //public Text fpsText; // reference to a Text component to display the FPS

    private float deltaTime;
    private float fps;
    GUIStyle textStyle = new();
    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f; // calculate the smoothed delta time
        fps = 1.0f / deltaTime; // calculate the FPS
        //fpsText.text = string.Format("{0:0.} FPS", fps); // update the FPS display text
    }

    void OnGUI()
    {
        //Display the fps and round to 2 decimals
        GUI.Label(new Rect(5, 5, 100, 50), "FPS: " + fps.ToString("F2"), textStyle);
    }
}
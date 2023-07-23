using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public GameObject winContainer;
    public GameObject loseContainer;

    void Start()
    {
        ScoreManager.instance.PlayerWon += WonScreen;
        GameManager.instance.PlayerLost += LostScreen;
    }

    private void WonScreen()
    {
        Time.timeScale = 0;
        winContainer.SetActive(true);
    }

    private void LostScreen()
    {
        Time.timeScale = 0;
        loseContainer.SetActive(true);
    }

    public void PlayAgain()
    {
        PlayLevelAgain();
        Time.timeScale = 1;
    }

    private void PlayLevelAgain()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private void Start() {
        Time.timeScale = 1f;
    }

    public void StartGame() {
        SceneManager.LoadScene("Game");
    }

    public void HowToPlay() {
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitApp() {
        Application.Quit(0);
    }

}

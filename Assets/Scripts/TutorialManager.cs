using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            MainMenu();
        }
    }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}

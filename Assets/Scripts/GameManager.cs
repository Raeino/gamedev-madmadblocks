using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public enum Section {
        Game,
        Pause,
        GameOver
    }

    public Section section;

    private readonly string TAG = "Highscore";

    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    public GameObject gameUI;

    public GameObject spawner;

    public Button btn;

    public GameObject player;
    private float highscore;

    public GameObject newBestGOWrap;

    public bool gameOver = false;
    private bool isGameOvering = true;

    private bool canPause = true;

    void Start()
    {
        section = Section.Game;
        Time.timeScale = 1f;
        highscore = PlayerPrefs.GetFloat(TAG, 0);
    }

    public void ResumeGame() {
        section = Section.Game;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame() {
        section = Section.Pause;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Button btn = GameObject.Find("ResumeWrap").GetComponent<Button>();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(btn.gameObject);
        canPause = false;
    }


    public void GameOver(float result) {
        section = Section.GameOver;
        gameOverUI.SetActive(true);
        Time.timeScale = 0.25f;
        Button btn = GameObject.Find("RetryWrap").GetComponent<Button>();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(btn.gameObject);
        Text scoreText = GameObject.Find("ResultText").GetComponent<Text>();
        scoreText.text = "RESULT SCORE: " + (Mathf.Round(result * 100f) / 100f).ToString().Replace(",", ".");

        if(result >= highscore) {
            PlayerPrefs.SetFloat(TAG, result);
            newBestGOWrap.SetActive(true);
        }
    }

    public void Retry() {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame() {
        SceneManager.LoadScene("MainMenu");
    }

    void Update()
    {
        if (section == Section.Game) {
            if (Input.GetKeyDown(KeyCode.Space) && canPause) {
                PauseGame();
            }

            if(Input.GetKeyUp(KeyCode.Space)) {
                canPause = true;
            }
        }

        if(section == Section.Pause) {
            if (Input.GetKeyDown(KeyCode.R)) {
                ResumeGame();
            }

            if(Input.GetKeyDown(KeyCode.Q)) {
                QuitGame();
            }
        }

        if(gameOver) {
            if(isGameOvering) {
                float resultScore = FindObjectOfType<ScoreUpdate>().score;
                GameOver(resultScore);
            }
            isGameOvering = false;
        }
    }
}

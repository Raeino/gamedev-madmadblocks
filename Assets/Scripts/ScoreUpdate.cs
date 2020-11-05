using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    private Text scoreText;
    public Text highscoreText;
    private float highscore;
    public float score = 0f;
    public GameObject player;
    public string scoreString;

    private const string TAG = "Highscore";

    private void Start() {
        scoreText = GetComponent<Text>();
        highscore = PlayerPrefs.GetFloat(TAG, 0);
        highscore = Mathf.Round(highscore * 100f) / 100f;
        highscoreText.text = "BEST: " + highscore.ToString().Replace(",", ".");
    }

    private void Update() {
        if(player != null) {
            score += Time.deltaTime;
            string theText = (Mathf.Round(score * 100f) / 100f).ToString().Replace(",", ".");
            scoreText.text = "SCORE: " + theText;

            if(score >= highscore) {
                highscoreText.text = "BEST: " + theText;
            }

        }

    }
}

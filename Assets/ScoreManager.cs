using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text tmpScore;
    public int score;

    void Awake()
    {
        instance = this;
        score = 0;
    }

    void Start()
    {
        ChangeScore(0);
    }

    public void SaveScore()
    {
        var high = PlayerPrefs.GetInt("highScore");
        if (score > high)
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }

    public void ChangeScore(int score)
    {
        this.score += score;
        SaveScore();
        tmpScore.text = "Score :" + this.score;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Firebase;

public class GameManager : MonoBehaviour
{

    public GameObject GameOverPanel;

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;

    int currentScore;

    void Start()
    {
        currentScore = 0;
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        SetScore();

        Firebase.Analytics.FirebaseAnalytics.SetAnalyticsCollectionEnabled(true); //iOS
    }


    void Update(){
    }


    public void CallGameOver()
    {
        StartCoroutine(GameOver());
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        GameOverPanel.SetActive(true);
        yield break;
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Firebase.Analytics.FirebaseAnalytics.SetAnalyticsCollectionEnabled(true); //iOS
        Firebase.Analytics.FirebaseAnalytics.LogEvent("restart");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Firebase.Analytics.FirebaseAnalytics.LogEvent("back2menu");
    }

    public void AddScore() 
    {
        currentScore++;
        if (currentScore > PlayerPrefs.GetInt("BestScore", 0)) 
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            bestScoreText.text = currentScore.ToString();
        }
        SetScore();
    }

    void SetScore()
    {
        currentScoreText.text = currentScore.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour{
    [SerializeField] Text scoreText;
    [SerializeField] Text highscoreText;
    [SerializeField] Text totalText;

    void Start(){
        GameManager.highscore = PlayerPrefs.GetInt("highscore", 0);
        GameManager.totalscore = PlayerPrefs.GetInt("total", 0);
        scoreText.text = "SCORE: " + GameManager.score.ToString();
        highscoreText.text = "HIGHSCORE: " + GameManager.highscore.ToString();
        totalText.text = "TOTAL: " + GameManager.totalscore.ToString();
        
    }
}

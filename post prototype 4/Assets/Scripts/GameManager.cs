using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    

    public static int score = 0;
    public static int totalscore; 
    public static int highscore;
    public static int gold = 0;
    public static GameManager inst;
    int speedboost = 0;


    [SerializeField] Text scoreText;

    //why is high score being saved in playerprefs but not total

    void start()
    {
        //PlayerPrefs.SetInt("total", totalscore);
    }

    public void IncrementScore(){
        score++;
        //display UI text
        scoreText.text = "SCORE: " + score + " GOLD: " + gold + " LIVES: " + Player.lives + " SPEED: +" + speedboost;
        //increase high score value if high score is lower than current score
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        totalscore++;
        PlayerPrefs.SetInt("total", totalscore);
    }

    //display update when gold is picked
    public void IncrementGold(){
        gold++;
        //display UI text
        scoreText.text = "SCORE: " + score + " GOLD: " + gold + " LIVES: " + Player.lives + " SPEED: +" + speedboost;
    }

    public void IncrementSpeedBoost()
    {
        speedboost++;
        //display UI text
        scoreText.text = "SCORE: " + score + " GOLD: " + gold + " LIVES: " + Player.lives + " SPEED: +" + speedboost;
    }


    private void Awake(){
        inst = this;
    }

}
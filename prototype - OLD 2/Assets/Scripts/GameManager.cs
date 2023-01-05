using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //<<TODO>>
    //store high score with log file and getters/setters
    //<<TODO>>

    int score;
    public static int gold = 0;
    public static GameManager inst;


    [SerializeField] Text scoreText;

    //display update when crystal is picked
    public void IncrementScore(){
        score++;
        scoreText.text = "SCORE: " + score + "   " + "GOLD: " + gold + "  " + "LIVES: " + Player.lives;
    }

    //display update when gold is picked
    public void IncrementGold(){
        gold++;
        scoreText.text = "SCORE: " + score + "   " + "GOLD: " + gold + "  " + "LIVES: " + Player.lives;
    }

    private void Awake(){
        inst = this;
    }

}
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    //<<TODO>>
    //store high score with log file and getters/setters
    //<<TODO>>

    //<<TODO>>
    //life counter
    //use MOD algorithim to increment lives by 1 every time gold increases by 10 
    //modify this: a mod b = a - b * floor(a/b)
    //<<TODO>>

    int score;
    int gold;
    //int Displives = player.lives();
    public static GameManager inst;

    [SerializeField] Text scoreText;
    [SerializeField] Text goldText;
    [SerializeField] Player player;

    //display when crystal is picked
    public void IncrementScore()
    {
        score++;
        scoreText.text = "SCORE: " + score + "   " + "GOLD: " + gold + "  " + "LIVES: not yet calculated by MOD algorithim";
    }

    //display when gold is picked
    public void IncrementGold()
    {
        gold++;
        scoreText.text = "SCORE: " + score + "   " + "GOLD: " + gold + "  " + "LIVES: not yet calculated by MOD algorithim";
    }

    private void Awake()
    {
        inst = this;
    }

}
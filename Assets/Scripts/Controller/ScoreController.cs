using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoSingleton<ScoreController>
{
    public int Score => score;

    private int score;

    public void Increase()
    {
        score++;

        if (score > PlayerPrefs.GetInt("BestScore"))
        {
            PlayerPrefs.SetInt("BestScore", score);
        } 
    }

}

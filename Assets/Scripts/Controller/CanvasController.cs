using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject deadPanel;
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private Text score;
    [SerializeField] private Text bestScore;
    [SerializeField] private Text endGameScore;



    private void Start() 
    {
        startPanel.SetActive(true);
        inGamePanel.SetActive(false);
        deadPanel.SetActive(false);

        GameController.Instance.StartGame += OnStartGame;
        Bird.Instance.BirdDie += OnBirdDie;
    }

    private void Update() 
    {
        score.text = ScoreController.Instance.Score.ToString();
    }

    private void OnBirdDie()
    {
        inGamePanel.SetActive(false);
        bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
        endGameScore.text = score.text;
        deadPanel.SetActive(true);
    }

    private void OnStartGame()
    {
        startPanel.SetActive(false);
        inGamePanel.SetActive(true);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject deadPanel;
    [SerializeField] private GameObject inGamePanel;

    private void Start() 
    {
        startPanel.SetActive(true);
        inGamePanel.SetActive(false);
        deadPanel.SetActive(false);

        GameController.Instance.StartGame += OnStartGame;
        Bird.Instance.BirdDie += OnBirdDie;
    }

    private void OnBirdDie()
    {
        inGamePanel.SetActive(false);
        deadPanel.SetActive(true);
    }

    private void OnStartGame()
    {
        startPanel.SetActive(false);
        inGamePanel.SetActive(true);
    }
}

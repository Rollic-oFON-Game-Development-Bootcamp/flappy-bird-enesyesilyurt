using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoSingleton<GameController>
{
    public event Action StartGame;

    public bool IsGameStart {get; set;}
    private bool isFirstPlay = true;

    private void Start() 
    {
        Bird.Instance.BirdDie += OnBirdDie;
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0) && !IsGameStart && isFirstPlay) 
        {
            isFirstPlay = false;
            StartGame?.Invoke();
        }
    }
        
    private void OnBirdDie()
    {
        Time.timeScale = 0;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}

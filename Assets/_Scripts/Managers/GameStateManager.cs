using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    public GameObject canvas;
    public GameState State { get; private set; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Kick the game off with the first state
    void Start() {
        DontDestroyOnLoad(gameObject);
        ChangeState(GameState.Starting);
    } 

    public void ChangeState(GameState newState) {

        State = newState;
        switch (newState) {
            case GameState.Starting:
                HandleStarting();
                break;
            case GameState.StartGame:
                HandleStartGame();
                break;
            case GameState.Win:
                HandleWinning();
                break;
            case GameState.Lose:
                HandleLosing();
                break;
            case GameState.Boss:
                HandleBoss();
                break;
            default:
                return;
        }
    }

    private void HandleStarting() {
       AudioManager.instance.PlayMusic(0);
    }

    private void HandleCutscene() {
       AudioManager.instance.PlayMusic(2);
    }

    private void HandleStartGame() {
       AudioManager.instance.PlayMusic(0);
    }

    private void HandleLosing() {
        canvas.SetActive(true);
        //pause time
        Time.timeScale = 0f;
    }

    private void HandleWinning() {
        AudioManager.instance.PlayMusic(1);
        SceneManager.LoadScene(1);
    }

    private void HandleBoss() {
       AudioManager.instance.PlayMusic(1);
    }

    public enum GameState
    {
        Starting = 0,
        SpawningHeroes = 1,
        Win = 2,
        Lose = 3,
        Boss= 4,
        StartGame=5
    }

    public void LoadGame() {
        SceneManager.LoadScene(2);
        canvas.SetActive(false);
        Time.timeScale = 1f;
        
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    public AudioClip musicOnStart;

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
            case GameState.Win:
                HandleWinning();
                break;
            case GameState.Lose:
                HandleLosing();
                break;
            case GameState.Boss:
                HandleLosing();
                break;
            default:
                return;
        }
    }

    private void HandleStarting() {
       AudioManager.instance.PlayMusic(0);
    }

    private void HandleCutscene() {
       AudioManager.instance.PlayMusic(1);
    }

    private void HandleStartGame() {
       AudioManager.instance.PlayMusic(0);
    }

    private void HandleLosing() {
       
    }

    private void HandleWinning() {
       
    }

    private void HandleBoss() {
       
    }

    public enum GameState
    {
        Starting = 0,
        SpawningHeroes = 1,
        Win = 2,
        Lose = 3,
        Boss= 4
    }
}

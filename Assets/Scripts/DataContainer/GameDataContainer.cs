
using Bounce.EventSystem;
using Bounce.Utilities;
using UnityEngine;

public class GameDataContainer : IGameServices
{

    private bool _initialiseGame;
    private bool _gameStarted;
    private bool _healthCollected;
    private bool _obstacleHit;
    private bool _gameOver;
    private bool _levelComplete;
    private int _health = 3;
    private int _score;
    private int _coin;
    private int _currentLevel = 1;
    private bool _pause = false;

    public bool InitialiseGame
    {
        get => _initialiseGame;

        set
        {
            _initialiseGame = value;
            EventManager.Instance.InvokeEvent(GameDataKeys.GameInitialised);
        }
    }
    public bool GameStarted
    {
        get => _gameStarted;

        set
        {
            _gameStarted = value;
            EventManager.Instance.InvokeEvent(GameDataKeys.GameStarted);
        }
    }
    public bool HealthCollected
    {
        get => _healthCollected;

        set
        {
            _healthCollected = value;
            EventManager.Instance.InvokeEvent(GameDataKeys.HealthUpdated);
        }
    }
    public bool ObstacleHit
    {
        get => _obstacleHit;

        set
        {
            _obstacleHit = value;
            EventManager.Instance.InvokeEvent(GameDataKeys.ObstacleHit);
        }
    }
    public bool GameOver
    {
        get => _gameOver;

        set
        {
            _gameOver = value;
            if (value)
                EventManager.Instance.InvokeEvent(GameDataKeys.GameOver);
        }
    }
    public bool Pause
    {
        get => _pause;

        set
        {
            _pause = value;
            EventManager.Instance.InvokeEvent(GameDataKeys.Pause);
        }
    }
    public bool LevelComplete
    {
        get => _levelComplete;

        set
        {
            _levelComplete = value;
            EventManager.Instance.InvokeEvent(GameDataKeys.LevelComplete);
        }
    }
    public int Health
    {
        get => _health;

        set
        {
            _health = value;
            EventManager.Instance.InvokeEvent(GameDataKeys.HealthUpdated);
        }
    }
    public int Coin
    {
        get => _coin;

        set
        {
            _coin = value;
            EventManager.Instance.InvokeEvent(GameDataKeys.CoinUpdated);
        }
    }
    public int Score
    {
        get => _score;

        set
        {
            _score = value;
            EventManager.Instance.InvokeEvent(GameDataKeys.ScoreUpdated);
        }
    }
    public int CurrentLevel
    {
        get => _currentLevel;

        set
        {
            _currentLevel = value;
        }
    }
    public Vector3 StartPosition { get; internal set; }
}

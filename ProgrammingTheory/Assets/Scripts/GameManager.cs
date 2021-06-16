using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] private bool _isGameOver;
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private Button _retryBtn;
    private EnemyCalc _enemyCalc;
    private PlayerController _playerController;
    private Timer _timer;
    private sceneManager _sceneManager;
    [SerializeField] private float _score;
    public float score { get { return _score; } private set { _score = value; } }

    private void Start()
    {
        _score = 0;
        _gameOverUI.gameObject.SetActive(false);
        _timer = GameObject.Find("TimerController").GetComponent<Timer>();
        _enemyCalc = GameObject.Find("EnemyCalc").GetComponent<EnemyCalc>();
        _playerController = GameObject.Find("PlayerCalc").GetComponent<PlayerController>();
        _sceneManager = GameObject.Find("SceneManager").GetComponent<sceneManager>();
        Time.timeScale = 1;
        _retryBtn.onClick.AddListener(_sceneManager.Retry);

    }

    private void Update()
    {
        GameOverTimer();
        
    }

    private void GameOverTimer()
    {
        if (_timer.timer <= 0)
        {
            _isGameOver = true;
        }

        if (_isGameOver)
        {
            Time.timeScale = 0;
            _gameOverUI.gameObject.SetActive(true);
        }

    }

    public void AddScore()
    {
        _score++;
    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    public void NewRound()
    {
        _enemyCalc.enemyResults.Clear();
        _playerController.playerResults.Clear();
        _enemyCalc.RandomCalc();
        _timer.AddTimer();
    }

    


}

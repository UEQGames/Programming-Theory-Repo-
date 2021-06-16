using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    
    [SerializeField] private GameObject _gameOverUI;
    [SerializeField] private TextMeshProUGUI _treasureCount;
    private EnemyCalc _enemyCalc;
    private PlayerController _playerController;
    private Timer _timer;
    private HighScore _highScore;
    private TreasureBox _treasureBox;
    private int _score;
    public int score { get { return _score; } private set { _score = value; } }
    private bool _isGameOver;
    private bool winRound;

    private void Start()
    {
        
        _gameOverUI.gameObject.SetActive(false);
        _timer = GameObject.Find("TimerController").GetComponent<Timer>();
        _enemyCalc = GameObject.Find("EnemyCalc").GetComponent<EnemyCalc>();
        _playerController = GameObject.Find("PlayerCalc").GetComponent<PlayerController>();
        _highScore = GameObject.Find("HighScoreController").GetComponent<HighScore>();
        _treasureBox = GameObject.Find("TreasureBox").GetComponent<TreasureBox>();
        _score = 0;

    }

    private void Update()
    {
        GameOverTimer();
        _treasureCount.SetText("Treasure Open: " + _score);
        if (_playerController.listSize == _enemyCalc.enemyResults.Count)
        {
            CheckResults();
        }


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
            _highScore.SaveData(_score);
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

    private void CheckResults()
    {


        for (int i = 0; i < _playerController.playerResults.Count; i++)
        {
            //If we find values at any point that don't match, return false
            if (_playerController.playerResults[i] != _enemyCalc.enemyResults[i])
            {
                GameOver();

            }
            else
            {
                //If we've made it this far, the lengths match and all values match
                winRound = true;

            }
            if (winRound)
            {
                AddScore();
                _treasureBox.OpenChest();
                NewRound();
                _playerController.listSize = 0;
                winRound = false;
              
                
            }

        }

    }

  


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TreasureCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _treasureText;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _treasureText.SetText("Treasure Count: 0");
    }

    private void Update()
    {
        _treasureText.SetText("Treasure Count: " + _gameManager.score);   
    }
}

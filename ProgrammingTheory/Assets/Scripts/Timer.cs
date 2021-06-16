using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timer;
    public float timer { get { return _timer; } private set { _timer = value; } }
    [SerializeField] private TextMeshProUGUI _timerUI;
    

    // Start is called before the first frame update
    void Start()
    {
        
        _timerUI.SetText("Timer: " + (int)_timer);
    }

    // Update is called once per frame
    void Update()
    {
        TimerCountdown();
    }

    private void TimerCountdown()
    {
        _timerUI.SetText("Timer: " + (int)_timer);
        _timer -= Time.deltaTime;

        if(_timer < 0)
        {
            _timer = 0;
        }
        
    }

    public void AddTimer()
    {
        _timer += Random.Range(10.0f, 20.0f);
    }

    
}

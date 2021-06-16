using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : CalcUI
{
    [SerializeField] private List<Button> _buttons = new List<Button>();
    [SerializeField] private Button _enter;
    [SerializeField] private Button _clear;
    [SerializeField] private AudioClip buttonSound;
    public List<int> playerResults = new List<int>();
    private SoundManager _soundManager;
    private string result;
    public int listSize { get; set; }
    


    void Start()
    {
        _soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        for (int i = 0; i < _buttons.Count; i++)
        {
            int cacheIndex = i; // we have to cache i to have the right value in the anonymous method
            _buttons[i].onClick.AddListener(() => ButtonClicked(cacheIndex));
        }
        _enter.onClick.AddListener(ShowCalc);
    }


    void ButtonClicked(int index)
    {
        _soundManager.PlaySound(buttonSound);
        builder.Append(index.ToString());
        result = (builder.ToString());
        calcUI.SetText(result);
    }

    //POLYMORPHISM
    protected override void ShowCalc()
    {
        _soundManager.PlaySound(buttonSound);
        int tempResult;
        int.TryParse(result, out tempResult);
        playerResults.Add(tempResult);
        listSize++;
        builder.Clear();
        calcUI.SetText("XXXX");

    }

    

    public void ClearBtn()
    {
        _soundManager.PlaySound(buttonSound);
        builder.Clear();
        calcUI.SetText("XXXX");
    }

}

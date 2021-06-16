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
    public List<int> playerResults = new List<int>();
    private string result;
    public int listSize { get; set; }
    


    void Start()
    {

        for (int i = 0; i < _buttons.Count; i++)
        {
            int cacheIndex = i; // we have to cache i to have the right value in the anonymous method
            _buttons[i].onClick.AddListener(() => ButtonClicked(cacheIndex));
        }
        _enter.onClick.AddListener(ShowCalc);
    }


    void ButtonClicked(int index)
    {
        builder.Append(index.ToString());
        result = (builder.ToString());
        calcUI.SetText(result);
    }

    protected override void ShowCalc()
    {
        int tempResult;
        int.TryParse(result, out tempResult);
        playerResults.Add(tempResult);
        listSize++;
        builder.Clear();
        calcUI.SetText("XXXX");

    }

    

    public void ClearBtn()
    {
        builder.Clear();
        calcUI.SetText("XXXX");
    }

}

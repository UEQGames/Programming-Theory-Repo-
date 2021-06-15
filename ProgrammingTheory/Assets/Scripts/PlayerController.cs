using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : CalcUI
{
    [SerializeField] private List<Button> _buttons = new List<Button>();
    [SerializeField] private Button _enter;
    private EnemyCalc enemyCalc;
    public List<int> playerResults = new List<int>();
    
    private string result;
    private StringBuilder _builder = new StringBuilder();
    private StringBuilder _builderText = new StringBuilder();

    void Start()
    {

        enemyCalc = GameObject.Find("EnemyCalc").GetComponent<EnemyCalc>();
        for (int i = 0; i < _buttons.Count; i++)
        {
            int cacheIndex = i; // we have to cache i to have the right value in the anonymous method
            _buttons[i].onClick.AddListener(() => ButtonClicked(cacheIndex));
        }
        _enter.onClick.AddListener(BuildString);
    }

    private void Update()
    {
                
        CheckResults();


    }

    void ButtonClicked(int index)
    {
        _builder.Append(index.ToString());
    }

    void BuildString()
    {
        int tempResult;
        result = (_builder.ToString());
        int.TryParse(result, out tempResult);
        playerResults.Add(tempResult);
        calcUI.SetText(result);
        _builder.Clear();
        


    }

    private bool CheckResults()
    {
        if (playerResults.Count != enemyCalc.enemyResults.Count)
        {
            return false;
        }

        for (var i = 0; i < playerResults.Count; i++)
        {
            //If we find values at any point that don't match, return false
            if (playerResults[i] != enemyCalc.enemyResults[i])

                return false;
        }


        //If we've made it this far, the lengths match and all values match
        return true;
    }

   


}

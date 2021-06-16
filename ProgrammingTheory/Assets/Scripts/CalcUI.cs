using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class CalcUI : MonoBehaviour
{
    //INHERITANCE
    [SerializeField] protected TextMeshProUGUI calcUI;
    protected StringBuilder builder = new StringBuilder();
    protected string calcString;

    protected virtual int GenerateRandomCalc() { return 0; }
    protected virtual void ShowCalc() 
    {
        calcString = builder.ToString();
        calcUI.SetText(calcString);
    }

  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using TMPro;

public class CalcUI : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI calcUI;
    protected string calcString;
    protected StringBuilder builder = new StringBuilder();

    protected virtual int GenerateRandomCalc() { return 0; }
    protected virtual void ShowCalc() 
    {
        calcString = builder.ToString();
        calcUI.SetText(calcString);
    }

  
}

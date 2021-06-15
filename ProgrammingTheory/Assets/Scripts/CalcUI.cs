using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class CalcUI : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI calcUI;

    protected virtual int GenerateRandomCalc() { return 0; }
    protected abstract void ShowCalc();

  
}

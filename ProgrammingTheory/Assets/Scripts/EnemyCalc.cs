using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyCalc : CalcUI
{
    private string calcString;
    private StringBuilder builder = new StringBuilder();
    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GenerateRandomCalc();
        }
        calcString = builder.ToString();
        calcUI.SetText(calcString);
    }

    protected override int GenerateRandomCalc()
    {
        int index = Random.Range(0, 4);
        int number1 = Random.Range(1, 101);
        int number2 = Random.Range(1, 101);
        int total;
        
        switch (index)
        {
            case 0:
                total = number1 + number2;
                builder.Append(("(" + number1.ToString() + " + " +  number2.ToString() + ") "));
                return Mathf.RoundToInt(total);
             
            case 1:
                total = number1 - number2;
                builder.Append(("(" + number1.ToString() + " - " + number2.ToString() + ") "));
                return Mathf.RoundToInt(total);
               
            case 2:
                total = number1 * number2;
                builder.Append(("(" + number1.ToString() +  " * " +  number2.ToString() + ") "));
                return Mathf.RoundToInt(total);
               
            case 3:
                total = number1 / number2;
                builder.Append(("(" + number1.ToString() + " / " +  number2.ToString() + ") "));
                return Mathf.RoundToInt(total);
                
        }
        return 0;
    }
    protected override void ShowCalc()
    {
        
    }
}

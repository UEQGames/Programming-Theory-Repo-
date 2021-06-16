using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCalc : CalcUI
{
    public List<int> enemyResults = new List<int>();
    
    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GenerateRandomCalc();
        }

        ShowCalc();
        
    }

    protected override int GenerateRandomCalc()
    {
        int index = Random.Range(0, 3);
        int number1 = Random.Range(1, 101);
        int number2 = Random.Range(1, 101);
        int total;
        
        switch (index)
        {
            case 0:
                total = number1 + number2;
                builder.Append(("(" + number1.ToString() + " + " +  number2.ToString() + ") "));
                if(total < 0)
                {
                    total = 0;
                }
                enemyResults.Add(Mathf.RoundToInt(total));
                return Mathf.RoundToInt(total);
             
            case 1:
                total = number1 - number2;
                builder.Append(("(" + number1.ToString() + " - " + number2.ToString() + ") "));
                if (total < 0)
                {
                    total = 0;
                }
                enemyResults.Add(Mathf.RoundToInt(total));
                return Mathf.RoundToInt(total);
               
            case 2:
                total = number1 * number2;
                builder.Append(("(" + number1.ToString() +  " * " +  number2.ToString() + ") "));
                if (total < 0)
                {
                    total = 0;
                }
                enemyResults.Add(Mathf.RoundToInt(total));
                return Mathf.RoundToInt(total);
               
           
                
        }
        return 0;
    }

    public void RandomCalc()
    {
        for (int i = 0; i < 4; i++)
        {
            GenerateRandomCalc();
        }
    }
  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureBox : MonoBehaviour
{
   
    [SerializeField] private Animator _treasureAnim;

   public void OpenChest()
    {
        _treasureAnim.SetTrigger("TreasureOpen");
        StartCoroutine(Coin());
    }

    IEnumerator Coin()
    {
        transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.8f);
        transform.GetChild(1).gameObject.SetActive(false);
    }
}

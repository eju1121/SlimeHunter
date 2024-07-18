using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    private GameManager randomGold;
    private int dropGold;
    private int curGold;


    private void ChangeGoldUI()
    {
        randomGold.GetGold();
    }
    
}

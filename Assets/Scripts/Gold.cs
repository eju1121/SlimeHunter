using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour //골드 텍스트만 바꿔주는 역할, 현재 골드량을 받아올 곳이 있어야함
{
    [SerializeField] private Text goldText;

    private float gold;
    public float curGold;
   
    private void Awake()
    {
        goldText=GetComponent<Text>();
    }

    public void ChangeGoldUI(float gold)
    {
        goldText.text = (gold.ToString() + "원");
    }
    
}

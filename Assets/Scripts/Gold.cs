using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour //��� �ؽ�Ʈ�� �ٲ��ִ� ����, ���� ��差�� �޾ƿ� ���� �־����
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
        goldText.text = (gold.ToString() + "��");
    }
    
}

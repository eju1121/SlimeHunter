using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour //��� �ؽ�Ʈ�� �ٲ��ִ� ����, ���� ��差�� �޾ƿ� ���� �־����
{
    private float gold;
    public float curGold;
    [SerializeField] private Text goldText;


    public void ChangeGoldUI(float gold)
    {
        goldText.text = (gold.ToString() + "��");
    }
    
}

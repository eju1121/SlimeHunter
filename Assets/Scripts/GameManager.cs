using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Monster[] slimes;
    [SerializeField] private float damage; //�ʱ� ���� ������
    [SerializeField] private int percent; //ũ��Ƽ�� ����
    private Monster curSlime;
    private float curDamage; //�ʱ� ������ �����
    [SerializeField] private float criticalDamage;
    private int criticalPrecent;
    private float Gold; //óġ �� ���� ��差
    private float curGold; //���� ���� ��差

    public void SpawnSlime()
    {
        int spawnIndex = UnityEngine.Random.Range(0, slimes.Length);
        GameObject newSlime = Instantiate(slimes[spawnIndex].gameObject);
        curSlime=newSlime.GetComponent<Monster>();
    }

    public void CheckCritical()
    {
        curDamage = damage;

        criticalPrecent = Random.Range(0, 100); //0~99
        if (criticalPrecent > percent)
        {
            curDamage = criticalDamage;
            Debug.Log("Critical Damage!");
        }  
    }

    public void GetGold()
    {
        if (curSlime == null)
        {
            Gold = Random.Range(1, 101);
            curGold += Gold;
            
        }
    }


    private void Update()
    {
        if (curSlime == null)
        {
            SpawnSlime();
        }
    }

    public void HitSlime()
    {
        if (curSlime != null)
        {
            CheckCritical();
            curSlime.OnHit(curDamage);
            curDamage = damage;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Monster[] slimes;
    [SerializeField] private float damage; //�ʱ� ���� ������
    [SerializeField] private int percent; //ũ��Ƽ�� ����
    [SerializeField] private float criticalDamage;

    private Monster curSlime;
    private Gold changeGold;

    private float curDamage; //�ʱ� ������ �����
    private int criticalPrecent;
    private float gold;
    private float curGold;

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

    private void Awake()
    {
        changeGold = FindObjectOfType<Gold>();
    }

    private void GetGold()
    {
        gold = curSlime.SlimeHoldGold();
        curGold += gold;
        changeGold.ChangeGoldUI(curGold);

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
        if (curSlime != null && curSlime.GetIsDead()==false)
        {
            CheckCritical();
            curSlime.OnHit(curDamage);
            curDamage = damage;

            if (curSlime.GetIsDead())
            {
                GetGold();
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Monster[] slimes;
    [SerializeField] private float damage; //초기 설정 데미지
    [SerializeField] private int percent; //크리티컬 기준
    private Monster curSlime;
    private float curDamage; //초기 데미지 저장용
    [SerializeField] private float criticalDamage;
    private int criticalPrecent;
    private float Gold; //처치 시 랜덤 골드량
    private float curGold; //현재 보유 골드량

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

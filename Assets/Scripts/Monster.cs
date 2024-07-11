//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private float maxHp;
    private float curHp;

    private bool isDead = false;

    private void Awake()
    {
        curHp = maxHp;
    }

    public void OnHit(float damage)
    {
        curHp -= damage;
        if (curHp<=0) {
            curHp = 0;
            isDead = true;
    }
        Debug.Log("Slime Hit!, Current Hp: " + curHp);

        if 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
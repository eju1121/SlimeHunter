//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
    [SerializeField] private HpBar hpBar;
    [SerializeField] private float maxHp;
    [SerializeField] private SlimeName slimeNameText;
    [SerializeField] private string slimeName;
    private float curHp;

    private bool isDead = false;
    private Animator animator;

    private void Awake()
    {
        curHp = maxHp;
        animator = GetComponent<Animator>();
        slimeNameText.ChangeSlimeName(slimeName);
    }

    public void OnHit(float damage)
    {
        curHp -= damage;

        if (curHp <= 0)
        {
            curHp = 0;
            isDead = true;
        }

        animator.SetTrigger("Hit");
        Debug.Log("Slime Hit!, Current Hp: " + curHp);
        hpBar.ChangeHpBarAmount(curHp / maxHp);

        if (isDead)
        {
            animator.SetTrigger("Death");
            Debug.Log("Slime is Dead");
            Destroy(gameObject, 1.5f);
        }
        
  
        
    }
}
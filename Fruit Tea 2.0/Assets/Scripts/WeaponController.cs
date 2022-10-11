using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Sword;

    public bool _canAttack = true;

    public float attackCooldown = 1.0f;

    public bool IsAttacking = false;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_canAttack)
            {
                SwordAttack();
            }
        }
    }
    
    public void SwordAttack()
    {
        IsAttacking = true;
        _canAttack = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetTrigger("attack");
        StartCoroutine(ResetAttackCooldown());
        

    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(attackCooldown);
        _canAttack = true;
        //Debug.Log("swing");
    }
    
    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        IsAttacking = false;
    }
}

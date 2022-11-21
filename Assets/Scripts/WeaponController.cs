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
        GetComponent<ThirdPersonMovement>().enabled = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetBool("attacking",true);
        StartCoroutine(ResetAttackCooldown());
        
    }

    IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(attackCooldown);
        GetComponent<ThirdPersonMovement>().enabled = true;
        _canAttack = true;
        //Debug.Log("swing");
    }
    
    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        IsAttacking = false;
        Animator anim = Sword.GetComponent<Animator>();
        anim.SetBool("attacking",false);
    }
}

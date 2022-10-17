using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public WeaponController wc;
    public PlayerManager pm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && wc.IsAttacking)
        {
            Debug.Log("hit");
            //other.GetComponent<Animator>().SetTrigger("Hit");
        }
    }
}

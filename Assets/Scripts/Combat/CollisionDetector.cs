using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public WeaponController wc;
    public PlayerManager pm;
    public BasicEnemy be;
    
    Material m_Material;

    //public int currentForm = 1;

    private void Start()
    {
        //currentForm = pm
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collide");
        m_Material = other.GetComponent<Renderer>().material;
        if (other.CompareTag("Enemy") && wc.IsAttacking)
        {
            Debug.Log("hit");
            //other.GetComponent<Animator>().SetTrigger("Hit");
            colorChange(pm.fruitForm);
        }
    }
    
    
    public void colorChange(int form) //this is a superficial form check
    {
        if (form == 1)
        {
            Debug.Log("ayo1");
            //hitCounter = 2;
            m_Material.color = Color.red;
            StartCoroutine(ResetColor());
        }
        else if (form == 2)
        {
            Debug.Log("ayo2");
            //hitCounter = 1;
            m_Material.color = Color.blue;
            StartCoroutine(ResetColor());
        }
        else
        {
            Debug.Log("ayo3");
            //hitCounter = 3;
            m_Material.color = Color.green;
            StartCoroutine(ResetColor());
        }
    }
    
    IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.5f);
        m_Material.color = Color.white;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReefAnim : MonoBehaviour
{
    private MovementInput input;
    private Animator anim;
    float timer = 0;
    [SerializeField] float timerSet;
    int comboHits;

    bool attacking = true;
    [SerializeField] ThirdPersonMovement moving;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetFloat("Blend", 1);

    }

    // Update is called once per frame
    void Update()
    {

        ///*
        if (Input.GetMouseButtonUp(0))
        {
            attacking = true;
            switch (comboHits)
            {
                case 0:
                    FirstHit();
                    break;
                case 1:
                    SecondHit();
                    break;
                case 2:
                    FinalHit();
                    break;
                default:
                    break;
            }
        }
        //*/



        if(moving.speed != 0 || attacking == false)
        {
            //anim.Play("Walk");
        } else if(attacking == true)
        {
            
        } else
        {

        }
        
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            comboHits = 0;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = false;
        }
    }

    void FirstHit()
    {
        
            attacking = true;
            Debug.Log("First Hit");
            anim.Play("FirstAttack");
            comboHits++;
            timer = timerSet;
        
    }
    void SecondHit()
    {
        
            Debug.Log("Second Hit");
            anim.Play("SecondAttack");
            comboHits++;
            timer = timerSet;
        
    }
    void FinalHit()
    {
        
            Debug.Log("Third Hit");
            anim.Play("FinalAttack");
            comboHits = 0;
            timer = 0;
        
    }



}

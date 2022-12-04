using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReefAnim : MonoBehaviour
{
    private MovementInput input;
    private Animator anim;
    //float timer = 0;
    //[SerializeField] float timerSet;
    public int comboHits;

    bool attacking = true;
    [SerializeField] ThirdPersonMovement moving;
    [SerializeField] float coolDown = 2f;
    private float nextFireTime = 0f;
    float lastClickedTime = 0;
    float maxComboDelay = 1f;
    float animTime = 0.7f;
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
        if (Input.GetMouseButtonDown(0))
        {
            attacking = true;
            lastClickedTime = Time.time;
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

        if (Time.time - lastClickedTime > maxComboDelay)
        {
            comboHits = 0;
        }

        if (moving.speed != 0 || attacking == false)
        {
            //anim.Play("Walk");
        } else if(attacking == true)
        {
            
        } else
        {

        }
        
        if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime > animTime && anim.GetCurrentAnimatorStateInfo(0).IsName("FirstAttack"))
        {
            anim.SetBool("firstHit", false);

        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > animTime && anim.GetCurrentAnimatorStateInfo(0).IsName("SecondAttack"))
        {
            anim.SetBool("secondHit", false);

        }
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > animTime && anim.GetCurrentAnimatorStateInfo(0).IsName("FinalAttack"))
        {
            anim.SetBool("finalHit", false);
            comboHits = 0;
        }

        /*
        if(Time.time - lastClickedTime > maxComboDelay)
        {
            comboHits = 0;
        }

        if(Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnClick();
            }
        }
        //*/

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = false;
        }
    }

    void FirstHit()
    {
        
            Debug.Log("First Hit");
            anim.Play("FirstAttack");
            comboHits++;
        
    }
    void SecondHit()
    {
        
            Debug.Log("Second Hit");
            anim.Play("SecondAttack");
            comboHits++;


    }
    void FinalHit()
    {
        
            Debug.Log("Third Hit");
            anim.Play("FinalAttack");
            comboHits = 0;


    }

    void OnClick()
    {
        moving.speed = 7f; //cut speed in half when attacking
        lastClickedTime = Time.time;
        comboHits++;
        if(comboHits == 1)
        {
            anim.SetBool("firstHit", true);
        }
        comboHits = Mathf.Clamp(comboHits, 0, 3);

        if (comboHits >= 2 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > animTime && anim.GetCurrentAnimatorStateInfo(0).IsName("FirstAttack"))
        {
            anim.SetBool("firstHit", false);
            anim.SetBool("secondHit", true);
        }

        if(comboHits >= 3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > animTime && anim.GetCurrentAnimatorStateInfo(0).IsName("SecondAttack"))
        {
            anim.SetBool("secondHit", false);
            anim.SetBool("finalHit", true);
        }
    }



}

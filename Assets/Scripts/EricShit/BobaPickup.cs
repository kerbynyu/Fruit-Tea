using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobaPickup : MonoBehaviour
{
    public float bobaRegular;
    public float bobaRare;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "B_Boba")//black boba
            {
                bobaRegular++;

            } else if(collision.gameObject.tag == "C_Boba")
            {
                bobaRare++;
            }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class BobaPickup : MonoBehaviour
{
    public float bobaRegular;
    public float bobaRare;

    public TextMeshProUGUI bobaRegularUI;
    public TextMeshProUGUI bobaRareUI;

    // Start is called before the first frame update
    void Start()
    {

        bobaRegular = 0;
        bobaRare = 0;


    }

    // Update is called once per frame
    void Update()
    {
        bobaRegularUI.text = bobaRegular + "";
        bobaRareUI.text = bobaRare + "" ; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "B_Boba")//black boba
            {
                bobaRegular++;
            Destroy(collision.gameObject);

            } else if(collision.gameObject.tag == "C_Boba")
            {
                bobaRare++;
            Destroy(collision.gameObject);

        }

    }
}

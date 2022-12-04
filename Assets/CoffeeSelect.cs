using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CoffeeSelect : MonoBehaviour
{

    public Animator anim; 

    // Start is called before the first frame update
    void Start()
    {
        anim.SetBool("Left", false);
        anim.SetBool("Right", false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left")) {
            anim.SetBool("Left", true);
            anim.SetBool("Right", false);
            print("left arrow key is held down");


        } else if ((Input.GetKey("right"))) {

            anim.SetBool("Right", true);
            anim.SetBool("Left", false);
            print("right arrow key is held down");
        }

        if((anim.GetBool("Right")== true)){
            if((Input.GetKey(KeyCode.Return) == true)) {
                Debug.Log("load scene watermelon");
                SceneManager.LoadScene("TheLevel2");
            }
          
        }
    }
}

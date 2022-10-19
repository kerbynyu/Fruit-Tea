using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //public menuController mc;
    public int maxHP;

    public int form;
    // Start is called before the first frame update
    void Start()
    {
        form = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            form = 1;
            Debug.Log("1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            form = 2;
            Debug.Log("2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            form = 3;
            Debug.Log("3");
        }
    }
}

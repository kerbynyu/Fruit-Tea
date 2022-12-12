using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EricHealth : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        //health = 150;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}

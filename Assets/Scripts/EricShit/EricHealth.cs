using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EricHealth : MonoBehaviour
{
    public float health;
    public GameObject deathMSG;
    public GameObject player;
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
            //UnityEditor.EditorApplication.isPlaying = false;
            deathMSG.SetActive(true);
            player.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    public WarpController controller;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 15f;
        controller = GameObject.FindGameObjectWithTag("Anims").GetComponent<WarpController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Sword" &&( controller.anim.GetBool("firstHit") || controller.anim.GetBool("secondHit") || controller.anim.GetBool("thirdHit")))
        {
            enemyHealth -= 5;
        }

        if(collision.gameObject.name == "body")
        {
            collision.gameObject.GetComponent<EricHealth>().health -= 5;
        }
    }
}

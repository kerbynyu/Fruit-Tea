using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float enemyHealth;
    public WarpController controller;
    public GameObject teaDrop;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = 15f;
        controller = GameObject.FindGameObjectWithTag("Anims").GetComponent<WarpController>();
        //teaDrop = Resources.Load("Assets/Prefabs/TeaDrop.prefab") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyHealth <= 0)
        {
            GameObject tea = Instantiate(teaDrop, gameObject.transform.position, teaDrop.gameObject.transform.rotation);
            controller.screenTargets.Remove(gameObject.transform);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Sword" &&( controller.anim.GetBool("firstHit") || controller.anim.GetBool("secondHit") || controller.anim.GetBool("finalHit")))
        {
            enemyHealth -= 5;
        }

        

        if(collision.gameObject.name == "body")
        {
            collision.gameObject.GetComponent<EricHealth>().health -= 5;
        }
    }
}

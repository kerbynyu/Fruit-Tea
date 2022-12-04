using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicAI : MonoBehaviour
{
    GameObject player;
    [SerializeField] float enemyAttackDistance;
    [SerializeField] float enemySpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //search for a player object to attack, make sure to add the tag to the player
    }

    // Update is called once per frame
    void Update()
    {
        //can GetComponent<Health> or smth to decrease health
        if(Vector3.Distance(player.gameObject.transform.position, gameObject.transform.position) < enemyAttackDistance)
        {
            transform.LookAt(player.gameObject.transform);//faces to player

            var speed = enemySpeed * Time.deltaTime; //make a speed variable depending on what is entered times Time. 
            //transform.position = Vector3.MoveTowards(transform.position, player.gameObject.transform.position, speed);
            transform.position += transform.forward * speed;

        }
    }


}

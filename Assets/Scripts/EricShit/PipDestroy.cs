using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipDestroy : MonoBehaviour
{
    private float timer;
    public GameObject hold;
    public bool canShoot;
    public Vector3 whereTo;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        canShoot = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer+= Time.deltaTime;
        if(timer < 0.2f)
        {
            gameObject.transform.position = hold.transform.position;
        }

        if(timer > 0.2f && canShoot == true)
        {
            ShootAt(whereTo, speed);
        }



        if (timer > 2f) //if we dont hit enemy in 2 seconds
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().enemyHealth -= 3;
            Destroy(gameObject); //Destroy itself
        }
    }

    public void ShootAt(Vector3 whereTo, float speed)
    {
        transform.position += transform.forward * speed; //shoots immediately forward
        transform.position = Vector3.Lerp(transform.position, whereTo, speed);

    }

    public void CanShoot()
    {
        canShoot = true;
    }
}

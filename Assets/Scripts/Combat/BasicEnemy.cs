using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    Material m_Material;

    public int hitCounter = 0;

    public int maxHit = 5;

    //public float colorBack = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        m_Material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (maxHit <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void colorChange(int form)
    {
        if (form == 1)
        {
            Debug.Log("ayo1");
            hitCounter = 2;
            m_Material.color = Color.red;
            StartCoroutine(ResetColor());
        }
        else if (form == 2)
        {
            Debug.Log("ayo2");
            hitCounter = 1;
            m_Material.color = Color.blue;
            StartCoroutine(ResetColor());
        }
        else
        {
            Debug.Log("ayo3");
            hitCounter = 3;
            m_Material.color = Color.green;
            StartCoroutine(ResetColor());
        }
    }
    
    IEnumerator ResetColor()
    {
        yield return new WaitForSeconds(0.5f);
        m_Material.color = Color.white;
    }
    
    void OnDestroy()
    {
        //Destroy the instance
        Destroy(m_Material);
    }
}

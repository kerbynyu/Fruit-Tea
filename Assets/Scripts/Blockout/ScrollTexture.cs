using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    // Start is called before the first frame update
    Material mat;
    
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = mat.GetTextureOffset("_BaseMap");
        mat.SetTextureOffset("_BaseMap", new Vector2(0, offset.y+0.0015f));
    }
}

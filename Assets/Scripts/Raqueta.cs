using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raqueta : MonoBehaviour
{

    public float velocidad = 30.0f;

    public string eje, eje2;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float v = Input.GetAxisRaw(eje);
        float h = Input.GetAxisRaw(eje2);

        GetComponent<Rigidbody2D>().velocity = new Vector2(h * velocidad, v * velocidad);

    }
}

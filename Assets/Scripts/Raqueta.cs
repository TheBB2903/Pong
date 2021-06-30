using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raqueta : MonoBehaviour
{

    public float velocidad = 30.0f;

    public string eje;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float v = Input.GetAxisRaw(eje);

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v * velocidad);

    }
}

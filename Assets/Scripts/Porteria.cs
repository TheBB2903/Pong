using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Porteria : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D bola)
    {

        if (bola.collider.name == "Bola")
        {

            if (this.name == "Izquierda")
            {

                bola.collider.GetComponent<Bola>().reiniciarBola("Derecha");

            }
            else if (this.name == "Derecha")
            {

                bola.collider.GetComponent<Bola>().reiniciarBola("Izquierda");

            }
        }
    }
}

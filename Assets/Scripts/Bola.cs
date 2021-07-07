using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bola : MonoBehaviour
{

    public float velocidad = 30.0f;

    AudioSource fuenteDeAudio;

    public AudioClip audioGol, audioRaqueta, audioRebote;

    public int golesIzquierda = 0;
    public int golesDerecha = 0;

    public float tiempo = 180;

    public Text contadorIzquierda;
    public Text contadorDerecha;
    public Text resultado;
    public Text temporizador;

    private string minutos, segundos;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;

        fuenteDeAudio = GetComponent<AudioSource>();

        contadorIzquierda.text = golesIzquierda.ToString();
        contadorDerecha.text = golesDerecha.ToString();

        resultado.enabled = false;

        Time.timeScale = 1;

    }

    void OnCollisionEnter2D(Collision2D micolision)
    {

        if (micolision.gameObject.name == "RaquetaIzquierda")
        {

            int x = 1;
            int y = direccionY(transform.position, micolision.transform.position);

            Vector2 direccion = new Vector2(x, y);

            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;

            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();

        }
        else if (micolision.gameObject.name == "RaquetaDerecha")
        {

            int x = -1;
            int y = direccionY(transform.position, micolision.transform.position);

            Vector2 direccion = new Vector2(x, y);

            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;

            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();

        }

        if (micolision.gameObject.name == "Arriba" || micolision.gameObject.name == "Abajo")
        {

            fuenteDeAudio.clip = audioRebote;
            fuenteDeAudio.Play();
        }

    }

    int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta)
    {

        if (posicionBola.y > posicionRaqueta.y)
        {
            return 1;
        }
        else if (posicionBola.y < posicionRaqueta.y)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }

    public void reiniciarBola(string direccion)
    {

        transform.position = Vector2.zero;

        velocidad = 30;

        if (direccion == "Derecha")
        {

            golesDerecha++;
            contadorDerecha.text = golesDerecha.ToString();

            if (!comprobarFinal())
            {

                GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;

            }
            
        }
        else if (direccion == "Izquierda")
        {

            golesIzquierda++;
            contadorIzquierda.text = golesIzquierda.ToString();

            if (!comprobarFinal())
            {

                GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;

            }

        }

        fuenteDeAudio.clip = audioGol;
        fuenteDeAudio.Play();
    }

    void Update()
    {
        

        velocidad = velocidad + 2 * Time.deltaTime;

        tiempo -= Time.deltaTime;

        if (!comprobarFinal())
        {
            minutosSegundos(tiempo);
        }
        else
        {
            minutosSegundos(0);
        }
    }

    void minutosSegundos(float tiempo)
    {

        if (tiempo > 120)
        {
            minutos = "02";
        }
        else if (tiempo >= 60)
        {
            minutos = "01";
        }
        else
        {
            minutos = "00";
        }

        int numSegundos = Mathf.RoundToInt(tiempo % 60);
        if (numSegundos > 9)
        {
            segundos = numSegundos.ToString();
        }
        else
        {
            segundos = "0" + numSegundos.ToString();
        }

        temporizador.text = minutos + ":" + segundos;

    }

    bool comprobarFinal()
    {

        if (tiempo <= 0)
        {

            if (golesIzquierda > golesDerecha)
            {
                resultado.text = "!Jugador Izquierdo GANA!\nCon " + golesIzquierda + " Goles \nPulsa I para volver a Inicio\nPulsa P para volver a jugar";
            }
            else if (golesDerecha > golesIzquierda)
            {
                resultado.text = "!Jugador Derecho GANA!\nCon " + golesDerecha + " Goles \nPulsa I para volver a Inicio\nPulsa P para volver a jugar";
            }
            else
            {
                resultado.text = "!EMPATE!\nPulsa I para volver a Inicio\nPulsa P para volver a jugar";
            }

            resultado.enabled = true;
            Time.timeScale = 0;
            return true;

        }
        if (golesIzquierda == 5)
        {

            resultado.text = "!Jugador Izquierdo GANA!\nCon " + golesIzquierda + " Goles \nPulsa I para volver a Inicio\nPulsa P para volver a jugar";
            resultado.enabled = true;
            Time.timeScale = 0;
            return true;

        }
        else if (golesDerecha == 5)
        {

            resultado.text = "!Jugador Derecho GANA!\nCon " + golesDerecha + " Goles \nPulsa I para volver a Inicio\nPulsa P para volver a jugar";
            resultado.enabled = true;
            Time.timeScale = 0;
            return true;

        }
        else
        {
            return false;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ControllerCovid : MonoBehaviour
{
    public int contador;
    public int contadorCovid;
    bool tiempoBool;

    string text;

    public Text TXTcontador;
    public Text TXTcontadorCovid;
    public Text TXTcontadorSano;

    public float tiempo;
    public Text TXTtiempo;

    public GameObject user;
    void Start()
    {
        contador = 1;
        tiempo = 0f;
        contadorCovid = 0;
        covid();
        tiempoBool = false;
        TXTtiempo.text = "Segundos :" + tiempo;
        TXTcontador.text = "Alumnos total: " + contador;
        TXTcontadorCovid.text = "Alumnos contagiados: " + (contadorCovid - 1);
        TXTcontadorSano.text = "Alumnos sanos: " + (1 + contador - contadorCovid);
    }

    void Update()
    {
        TXTcontador.text = "Alumnos total: " + contador;
        TXTcontadorCovid.text = "Alumnos contagiados: " + (contadorCovid-1);
        TXTcontadorSano.text = "Alumnos sanos: " + (1+contador-contadorCovid);



        if (1 + contador - contadorCovid == 0)
        {
            tiempoBool = false;
        }

        if (tiempoBool == true)
        {
            tiempo += Time.deltaTime;
            TXTtiempo.text = "Segundos: " + tiempo.ToString("f0");
        }
    }

    public void agregar()
    {
        Debug.Log(contador - contadorCovid);
        if (1+contador - contadorCovid != 0)
        {
            contador++;
            Instantiate(user);
        }
    }

    public void IniciarTiempo()
    {
        if (tiempoBool == false)
        {
            tiempoBool = true;
        }
    }


    public void covid()
    {
        Debug.Log("EEC");
        contadorCovid++;
        Debug.Log(contadorCovid);
    }

    public void reiniciar()
    {
        SceneManager.LoadScene("Simulador");
    }
}

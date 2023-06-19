using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider2D))]
public class Usuario : MonoBehaviour
{
    ControllerCovid Simulador;

    private Vector3 screenPoint;
    private Vector3 offset;

    public float velocidad = 5;
    public Rigidbody2D rb;
    private Vector2 inicioPos;
    public bool covid = false;

    SpriteRenderer usuario;

  //  public GameObject user;
    void Start()
    {
        transform.position = inicioPos;
        usuario = GetComponent<SpriteRenderer>();
 //       Instantiate(user);
 //       Instantiate(user);
        Inicio();
    }

    public void Inicio()
    {
        float x = Random.Range(0, 2) == 0 ? -1:1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;

        rb.velocity = new Vector2(velocidad * x+1, velocidad * y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "covid")
        {
            transform.gameObject.tag = "covid";
            covid = true;
        }
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = curPosition;

        if (Input.GetMouseButtonDown(1))
        {
            transform.gameObject.tag = "covid";
            covid = true;
        }
    }

    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }



    void Update()
    {
        if(covid == true)
        {
            if (usuario.color != new Color(0, 200, 0)) {
                usuario.color = new Color(0, 200, 0);
                Simulador = GameObject.FindGameObjectWithTag("menu").GetComponent<ControllerCovid>();
                Simulador.covid();
                Simulador.IniciarTiempo();
            }
        }
    }
}

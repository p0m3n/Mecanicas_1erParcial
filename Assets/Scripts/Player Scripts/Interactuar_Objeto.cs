﻿using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class Interactuar_Objeto : Player
{
    public Transform puntoDeAgarre; //pap�
    private GameObject objetoEnZona; //candidato a hijo
    private GameObject objetoAgarrado; //hijo
    public bool estaAgarrando = false;
    private Rigidbody2D rbObjeto;
    public float fuerzaDeArroje = 10f;
    public float anguloDeArrojeNormal = 45f;//lanzar en arco
    public float anguloDeArrojeVertical = 65f;//lanzar mas alto

    public void AgarrarSoltar()
    {
        //AGARRAR OBJETO
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (estaAgarrando) // Soltar
            {
                Debug.Log("TOY SOLTANDO");
                rbObjeto = objetoAgarrado.GetComponent<Rigidbody2D>();
                rbObjeto.simulated = true;
                //rbObjeto.bodyType = RigidbodyType2D.Dynamic;

                objetoAgarrado.transform.SetParent(null);
                objetoAgarrado = null;
                estaAgarrando = false;
            }

            else if (objetoEnZona != null && !grabbingLedge) // Agarrar
            {
                Debug.Log("TOY AGARRANDO");
                objetoAgarrado = objetoEnZona; //se hace esto para que solo haya un objeto agarrado

                rbObjeto = objetoAgarrado.GetComponent<Rigidbody2D>();
                //rbObjeto.bodyType = RigidbodyType2D.Kinematic;
                rbObjeto.simulated = false; //se quitan las fisicas para que el objeto siga al padre mientras salta

                objetoAgarrado.transform.position = puntoDeAgarre.position;
                objetoAgarrado.transform.SetParent(puntoDeAgarre);
                estaAgarrando = true;
            }
        }
    }

    public void Arrojar()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("TOY ARROJANDO PA LIBA");
            objetoAgarrado.transform.SetParent(null);
            rbObjeto.simulated = true;
            //float anguloFinal = anguloDeArrojeVertical * Mathf.Deg2Rad;

            //int direccion = transform.localScale.x > 0 ? 1 : -1;
            //Vector2 fuerzaArco = new Vector2(Mathf.Cos(anguloFinal) * direccion, Mathf.Sin(anguloFinal)) * fuerzaDeArroje;
            rbObjeto.AddForce(new Vector2(0f, fuerzaDeArroje), ForceMode2D.Impulse);
            objetoAgarrado = null;
            estaAgarrando = false;
        }

        else if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("TOY ARROJANDO");
            objetoAgarrado.transform.SetParent(null);
            rbObjeto.simulated = true;
            float anguloFinal = anguloDeArrojeNormal * Mathf.Deg2Rad;

            int direccion = transform.localScale.x > 0 ? 1 : -1;
            Vector2 fuerzaArco = new Vector2(Mathf.Cos(anguloFinal) * direccion, Mathf.Sin(anguloFinal)) * fuerzaDeArroje;
            rbObjeto.AddForce(fuerzaArco, ForceMode2D.Impulse);
            objetoAgarrado = null;
            estaAgarrando = false;
        }

        //else if (Input.GetKeyDown(KeyCode.E))
        //{
        //    Debug.Log("TOY ARROJANDO");
        //    objetoAgarrado.transform.SetParent(null);
        //    rbObjeto.simulated = true;
        //    float anguloFinal = anguloDeArrojeNormal * Mathf.Deg2Rad;

        //    int direccion = transform.localScale.x > 0 ? 1 : -1;
        //    Vector2 fuerzaArco = new Vector2(Mathf.Cos(anguloFinal) * direccion, Mathf.Sin(anguloFinal)) * fuerzaDeArroje;
        //    rbObjeto.AddForce(fuerzaArco, ForceMode2D.Impulse);
        //    objetoAgarrado = null;
        //    estaAgarrando = false;
        //}



    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Agarrable"))
        {
            objetoEnZona = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Agarrable"))
        {
            objetoEnZona = null;
        }
    }

}

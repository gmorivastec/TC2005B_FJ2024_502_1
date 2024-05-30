using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploSM : MonoBehaviour
{

    // simbolos
    private Simbolo _reganar, _alimentar, _acariciar;

    // estados 
    private Estado _feliz, _triste, _comiendo, _actual;


    // Start is called before the first frame update
    void Start()
    {
        // simbolos (inicializacion)
        _reganar = new Simbolo("Regañar");
        _alimentar = new Simbolo("Alimentar");
        _acariciar = new Simbolo("Acariciar");

        // estados (inicializacion)
        _feliz = new Estado("Feliz");
        _triste = new Estado("Triste");
        _comiendo = new Estado("Comiendo");

        // funcion de transferencia
        _feliz.AgregarTransicion(_reganar, _triste);

        _triste.AgregarTransicion(_alimentar, _comiendo);

        _comiendo.AgregarTransicion(_acariciar, _feliz);

        // estado inicial
        _actual = _feliz;      
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            _actual = _actual.AplicarSimbolo(_reganar);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            _actual = _actual.AplicarSimbolo(_alimentar);
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            _actual = _actual.AplicarSimbolo(_acariciar);
        }

        print(_actual.Nombre);
    }
}

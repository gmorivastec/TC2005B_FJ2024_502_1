using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploSM : MonoBehaviour
{

    // CÓMO DEDICIR QUÉ TAN COMPLEJA HACER MI LÓGICA 
    // - si jala con un if usa un if
    // - si necesitas muchos ifs anidados usa una máquina de estados
    // - si necesitas muchos nodos, sobre todo si son parecidos, usa un árbol de comportamiento
    // https://www.gamedeveloper.com/programming/behavior-trees-for-ai-how-they-work

    [SerializeField]
    private Transform _objetivo;

    [SerializeField]
    private float _distanciaMinima = 2;

    // simbolos
    private Simbolo _reganar, _alimentar, _acariciar;

    // estados 
    private Estado _feliz, _triste, _comiendo, _actual;

    private MonoBehaviour _behaviourActual;


    // Start is called before the first frame update
    void Start()
    {
        // simbolos (inicializacion)
        _reganar = new Simbolo("Regañar");
        _alimentar = new Simbolo("Alimentar");
        _acariciar = new Simbolo("Acariciar");

        // estados (inicializacion)
        _feliz = new Estado("Feliz", typeof(FelizBehaviour));
        _triste = new Estado("Triste", typeof(TristeBehaviour));
        _comiendo = new Estado("Comiendo", typeof(ComiendoBehaviour));

        // funcion de transferencia
        _feliz.AgregarTransicion(_reganar, _triste);

        _triste.AgregarTransicion(_alimentar, _comiendo);

        _comiendo.AgregarTransicion(_acariciar, _feliz);

        // estado inicial
        _actual = _feliz;
        // agregar dinámicamente comportamiento
        _behaviourActual = gameObject.AddComponent(_actual.Behaviour) as MonoBehaviour;

        StartCoroutine(VerificacionDistancia());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            CambiarEstado(_reganar);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            CambiarEstado(_alimentar);
        }
/*
        if(Input.GetKeyDown(KeyCode.C))
        {
            CambiarEstado(_acariciar);
        }
*/
        //print(_actual.Nombre);
    }

    private void CambiarEstado(Simbolo simbolo)
    {

        Estado temporal = _actual.AplicarSimbolo(simbolo);

        // si el estado no cambio no hagas nada 
        if(temporal == _actual)
            return;

        // si sí hubo cambio caemos aquí 

        // actualizar _actual 
        _actual = temporal;

        // remover comportamiento actual 
        Destroy(_behaviourActual);

        // agregar nuevo comportamiento
        _behaviourActual = gameObject.AddComponent(_actual.Behaviour) as MonoBehaviour;

        // alternativas 
        // - quitar y poner gameobjects hijos con los componentes apropiados
        // - habilitar y deshabilitar 
    }

    private IEnumerator VerificacionDistancia()
    {
        while(true)
        {
            if(Vector3.Distance(transform.position, _objetivo.position) < _distanciaMinima)
            {
                CambiarEstado(_acariciar);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}

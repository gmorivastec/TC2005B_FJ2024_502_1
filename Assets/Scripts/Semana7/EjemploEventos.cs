using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

[Serializable]
public class Evento1Args : UnityEvent<string> {}

[Serializable]
public class Evento2Args : UnityEvent<string, bool> {}

public class EjemploEventos : MonoBehaviour
{

    [SerializeField]
    private UnityEvent _evento0;

    [SerializeField]
    private Evento1Args _evento1;

    [SerializeField]
    private Evento2Args _evento2;

    // Start is called before the first frame update
    void Start()
    {
        // a un evento se le pueden agregar suscriptores / oyentes / observadores 
        // desde el editor o programáticamente

        // gran ventaja de los eventos - desacopla lógica
        // NO hay necesidad de conocer al tipo del oyente
        // el código es más reutilizable 
        _evento0.AddListener(EjemploObservador);
    }

    void EjemploObservador()
    {
        print("EVENTO ESCUCHADO PROGRAMÁTICAMENTE");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            _evento0.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            // invoke con unity events con parametros
            // exige que mande los valores del tipo y orden correspondiente
            _evento1.Invoke("EJEMPLO DE VALOR PASADO");
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            _evento2.Invoke("EVENTO 2", true);
        }
    }
}

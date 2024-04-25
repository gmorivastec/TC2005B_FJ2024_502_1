using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Disparador : MonoBehaviour
{
    [SerializeField]
    private GameObject _original;

    [SerializeField]
    private Transform _referencia;

    private IEnumerator _enumerator, _enumeratorDisparo;
    private Coroutine _coroutine;

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(_original, "ORIGINAL ES NULO EN DISPARADOR");
        Assert.IsNotNull(_referencia, "REFERENCIA ES NULO"); 
        
        StartCoroutine(EjemploTimer());
        //StartCoroutine("EjemploTimer");
        _enumerator = EjemploRecurrencia();
        _coroutine = StartCoroutine(_enumerator);
        _enumeratorDisparo = Disparar();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            StartCoroutine(_enumeratorDisparo);
        }

        if(Input.GetButtonUp("Jump"))
        {
            StopCoroutine(_enumeratorDisparo);
        }

        // mecanismos para detener corrutinas
        if(Input.GetKeyDown(KeyCode.I))
        {
            // DETENER TODO 
            StopAllCoroutines();
        }

        // detener una en específico
        if(Input.GetKeyDown(KeyCode.O))
        {
            // si la inicie con string la puedo detener así
            // StopCoroutine("EjemploRecurrencia");

            // detener con ienumerator
            StopCoroutine(_enumerator);

            // detener con coroutine
            //StopCoroutine(_coroutine);
        }
    }

    // corrutinas! 
    // solución de Unity para lidiar con lógica concurrente
    // no es un hilo
    // es un pseudo flujo paralelo que depende del script

    // casos de uso:
    // 1. flujo paralelo con un timer
    // 2. loop paralelo al update
    // 3. para código asíncrono (Ejemplo: request de HTTP)

    // flujo paralelo con un timer 
    public IEnumerator EjemploTimer()
    {
        yield return new WaitForSeconds(2);
        print("CORRUTINA");
    }

    public IEnumerator EjemploRecurrencia()
    {
        while(true)
        {
            print("RECURRENTE");
            yield return new WaitForSeconds(1);
        }
    }

    public IEnumerator Disparar()
    {
        while(true)
        {
            // DISPARA!
            // el proceso de crear nuevos game objects a partir de otros
            // se llama instanciado
            // necesitamos un original!
            Instantiate(
                _original,
                _referencia.position,
                _referencia.rotation
            );
            yield return new WaitForSeconds(0.75f);
        }
    }
}

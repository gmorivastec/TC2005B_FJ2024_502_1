using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// cómo inyectar lógica a un jueguito! 
// no tenemos control del flujo general de la ejecución de código

// vamos a inyectar lógica en momentos específicos de la ejecución de un script
// ciclo de vida
// se traduce en una serie de métodos que podemos redefinir
// C# es el lenguaje que vamos a usar 
// .NET

// : hereda de 
// MonoBehaviour
public class Movimiento : MonoBehaviour
{

    // en unity podemos usar atributos de la clase como valores parametrizables
    [SerializeField]
    private float _velocidad = 5;

    // se ejecuta una vez al inicio de la vida del script 
    // no le importa si el componente está habilitado o no 
    void Awake() 
    {
        print("AWAKE.");
    }

    // se ejecuta una vez al inicio después de awake
    // NO se ejecuta si el componente está deshabilitado
    // los dos se usan para SETUP!
    void Start()
    {

        // Método estático definido en la clase Debug
        Debug.Log("START");
    }

    // Update is called once per frame
    // frame?
    // fps - frames per second
    // frame viene de el cine / animación 
    // un video está partido en cuadros discretos que son como fotos
    // frame - el juego genera cuadros a su vez en tiempo real
    // procesar lógica + procesar gráficos
    // desempeño se mide en fps
    // 30 fps mínimo aceptable
    // 60+ deseable
    // intervalo de tiempo es variable
    void Update()
    {

        // vamos a limitar la lógica en update a 2 cosas
        // - movimiento
        // - input
        //print("UPDATE");

        // vamos a mover al cubito!
        //transform.Translate(_velocidad * Time.deltaTime, 0, 0);

        // vamos a meterle input! 
        // - sondeo (polling) directo a dispositivo
        // - sondeo (polling) a ejes 
        // - nuevo sistema de input

        if(Input.GetKeyDown(KeyCode.T))
        {
            print("KEY DOWN");
        }

        if(Input.GetKey(KeyCode.T))
        {
            print("KEY");
        }

        if(Input.GetKeyUp(KeyCode.T))
        {
            print("KEY UP");
        }

        if(Input.GetMouseButtonDown(0))
        {
            print("MOUSE DOWN");
        }

        // sondeo a ejes
        // ejes tienen valor con rango [-1, 1]
        // valor neutral es 0
        // GetAxis - suavizado con parámetros
        // GetAxisRaw - entrada directa de input
        float h = Input.GetAxisRaw("Horizontal"); 
        float v = Input.GetAxis("Vertical");
        //print(h + ", " + v);
        transform.Translate(
            h * _velocidad * Time.deltaTime, 
            v * _velocidad * Time.deltaTime, 
            0
        );

        // los ejes pueden ser sondeados como botón
        if(Input.GetButtonDown("Jump"))
        {
            print("PRESIONASTE JUMP!");
        }
    }

    // Fixed - Fijo
    void FixedUpdate()
    {

        // método que se ejecuta en intervalos definidos de tiempo
        //print("FIXED UPDATE");

    }

    // se ejecuta junto con Update (en cada frame) una vez que todos los 
    // updates están terminados
    void LateUpdate()
    {
        //print("LATE UPDATE");
    }
}

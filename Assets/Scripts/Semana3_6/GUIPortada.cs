using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIPortada : MonoBehaviour
{
    // vamos a empezar a utilizar eventos en Unity
    // evento es un suceso que detona acciones en otros objetos
    // sigue un patrón de diseño que se llama observer

    public void BotonPresionado()
    {
        print("BOTON PRESIONADO");
        // las escenas pueden cargarse de manera 
        // síncrona o asíncrona
        // - síncrona descarga la actual y carga la nueva
        // - asíncrona carga la nueva en memoria y espera instrucciones

        // para cargar escena podemos referirnos a ella con su indice
        // o su nombre
        // DEBE ser parte de la config del build
        //SceneManager.LoadScene(1);
        SceneManager.LoadScene("Semana3");
    }

    public void SliderCambio(float valor)
    {
        print(valor);
    }
}

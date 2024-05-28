using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIPortada : MonoBehaviour
{

    [SerializeField]
    private TMP_Text _contadorText;

    private int _contador;
    // vamos a empezar a utilizar eventos en Unity
    // evento es un suceso que detona acciones en otros objetos
    // sigue un patrón de diseño que se llama observer

    void Start()
    {
        // cómo saber cuándo definir un método?
        // si tienes que hacer copy-paste define un método
        RefrescarContador();
    }

    private void RefrescarContador()
    {
        _contador = PlayerPrefs.GetInt("Valorcito", 0);
        _contadorText.text = _contador + "";
    }

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

    public void IncrementarValor()
    {
        _contador++;
        _contadorText.text = _contador + "";
        PlayerPrefs.SetInt("Valorcito", _contador);

    }

    public void BorrarPrefs()
    {
        PlayerPrefs.DeleteKey("Valorcito");
        RefrescarContador();
        //PlayerPrefs.DeleteAll();
    }
}

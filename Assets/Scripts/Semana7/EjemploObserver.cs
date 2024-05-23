using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploObserver : MonoBehaviour
{
    public void EjemploEvento0()
    {
        print("EVENTO SUSCRITO POR EDITOR");
    }

    // para evento1
    public void EjemploEvento1(string s)
    {
        print("VALOR RECIBIDO: " + s);
    }

    // para evento2
    public void EjemploEvento2(string s, bool b)

    {
        print("VALORES RECIBIDOS: " + s + ", " + b);
    }
}

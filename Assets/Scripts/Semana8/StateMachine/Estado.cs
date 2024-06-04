using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Estado 
{
    
    public string Nombre
    {
        private set;
        get;
    }

    public Type Behaviour 
    { 
        private set;
        get;  
    }


    // para definir la función de transferencia vamos a usar un diccionario
    // diccionario es una estructura de datos en donde los datos están guardados
    // utilizando un objeto como llave 
    // similar a un arreglo pero en lugar de un índice numérico es un objeto
    private Dictionary<Simbolo, Estado> _transferencia;

    public Estado(string nombre, Type behaviour)
    {
        this.Nombre = nombre;
        this.Behaviour = behaviour;
        _transferencia = new Dictionary<Simbolo, Estado>();
    }

    public void AgregarTransicion(Simbolo simbolo, Estado estado)
    {
        _transferencia.Add(simbolo, estado);
    }

    public Estado AplicarSimbolo(Simbolo simbolo)
    {
        if(_transferencia.ContainsKey(simbolo))
            return _transferencia[simbolo];

        return this;
    } 
}


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

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(_original, "ORIGINAL ES NULO EN DISPARADOR");
        Assert.IsNotNull(_referencia, "REFERENCIA ES NULO");       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
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
        }
    }
}

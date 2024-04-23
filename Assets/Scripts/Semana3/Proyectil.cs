using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// require component - obliga al editor a asegurarse
// que el gameobject tiene el componente que marcamos como requerido
// - al agregar este componente agrega el requerido
// - al tratar de quitar el requerido no lo permite
[RequireComponent(typeof(Rigidbody))]
public class Proyectil : MonoBehaviour
{

    [SerializeField]
    private float _fuerza = 10;
    private Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        // la física utiliza espacio del mundo

        // para obtener "arriba", "derecha", "frente" utilizamos 
        // transform.up
        // transform.right
        // transform.forward
        // estos vectores ya están en espacio global
        // todos estos son vectores unitarios

        _rigidbody.AddForce(
            transform.up * _fuerza,
            ForceMode.Impulse
        );

        // agregamos una estrategia de destrucción por tiempo
        Destroy(gameObject, 4);
    }

    void OnCollisionEnter(Collision c)
    {
        // otra estrategia - al chocar
        // podrías checar layer y tag
        if(c.gameObject.tag == "Enemigo")
            Destroy(gameObject);
    }
}

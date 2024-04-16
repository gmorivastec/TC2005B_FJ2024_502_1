using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions;

public class Colisiones : MonoBehaviour
{
    
    [SerializeField]
    private TMP_Text _textito;

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(_textito, "TEXTITO ES NULO, VERIFICAR");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // colisiones!
    // al menos 2 maneras de detectar colisiones
    // - por medio del motor de física
    // - utilizando character controller

    // en videojuegos una colisión no implica un choque violento
    // puede ser un toquecito

    // hay más cosas que se pueden hacer como raycast

    // el motor de física
    // requisitos:
    // - al menos 2 objetos involucrados
    // - todos los involucrados tienen collider
    // - el GO (game object) que se mueve tiene rigidbody

    // al haber colisiones se detonan diferentes mensajes 
    // los mensajes pueden ser definidos en cualquier GO involucrado en la colisión

    void OnCollisionEnter(Collision collision)
    {
        // collision lo recibimos con info referente a la collision
        // - referencia a los involucrados
        // - puntos de contacto
        // - fuerzas involucradas
        print(
            "ENTER: " + 
            collision.transform.name + 
            " " + 
            collision.gameObject.layer +
            " " +
            collision.transform.tag
        );
    }

    void OnCollisionStay(Collision collision)
    {
        print("STAY");
    }

    void OnCollisionExit(Collision collision)
    {
        print("EXIT");
    }

    // caso particular: queremos que el motor de física mueva al objeto
    // pero no queremos que la colisión lo afecte

    // utilizamos triggers
    void OnTriggerEnter(Collider collider)
    {
        // collider es una referencia al componente collider
        // del objeto con el que colisionamos
        print("TRIGGER ENTER");
        _textito.text = "HUBO COLISIÓN!";
    }

    void OnTriggerStay(Collider collider)
    {
        print("TRIGGER STAY");
    }

    void OnTriggerExit(Collider collider)
    {
        print("TRIGGER EXIT");
    }
}

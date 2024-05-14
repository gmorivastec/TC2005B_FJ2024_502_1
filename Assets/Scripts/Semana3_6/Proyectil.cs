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
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
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
        // Destroy(gameObject, 4);
        StartCoroutine(Destruccion(4));
    }

    void OnDisable()
    {
        _rigidbody.velocity = Vector3.zero;
        StopAllCoroutines();
    }

    IEnumerator Destruccion(float time)
    {
        yield return new WaitForSeconds(time);
        BulletPool.Instance.ReturnBullet(gameObject);
    }
    void OnCollisionEnter(Collision c)
    {
        // otra estrategia - al chocar
        // podrías checar layer y tag
        if(c.gameObject.tag == "Enemigo")
        {
            // uso de properties
            // GUIManager.Instance = null; // AQUÍ SE VE COMO LA PROPIEDAD REGULA EL ACCESO
            
            // alternativa más común pero menos eficiente de todas:
            // gameObject.Find

            GUIManager.Instance.SetText(gameObject.name);
            //Destroy(gameObject);
            BulletPool.Instance.ReturnBullet(gameObject);
        }
            
    }
}

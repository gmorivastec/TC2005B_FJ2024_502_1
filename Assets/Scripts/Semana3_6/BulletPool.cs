using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{

    // pool - fuente común de recursos
    // buena idea para juegos donde hay mucha creación / destrucción
    // cómo funciona:
    // - existe un acervo común de game objects
    // - al necesitar uno se habilita y se "saca"
    // - al desocupar se deshabilita y se "guarda" 

    // habilitar / deshabilitar es más económico en performance que crear / destruir

    [SerializeField]
    private GameObject _original;

    [SerializeField]
    private int _poolSize;

    // fila / cola - FIFO
    private Queue<GameObject> _pool; 

    public static BulletPool Instance
    {
        get;
        private set;
    }

    void Awake()
    {
        if (Instance == null) 
            Instance = this;
        else
            Destroy(gameObject);  
    }


    // Start is called before the first frame update
    void Start()
    {
        // inicializar pool
        _pool = new Queue<GameObject>();

        // loop para creación de objetos
        for(int i = 0; i < _poolSize; i++)
        {
            // crear nuevo objeto
            GameObject nuevo = Instantiate(_original) as GameObject;

            // deshabilitarlo 
            nuevo.SetActive(false);

            // guardar en pool
            _pool.Enqueue(nuevo);
        }
    }


    public GameObject GetBullet(Vector3 position, Quaternion rotation)
    {

        if(_pool.Count == 0)
            return null;

        GameObject resultado = _pool.Dequeue();
        resultado.SetActive(true);
        resultado.transform.position = position;
        resultado.transform.rotation = rotation;
        return resultado;
    }

    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        _pool.Enqueue(bullet);
    }    
}

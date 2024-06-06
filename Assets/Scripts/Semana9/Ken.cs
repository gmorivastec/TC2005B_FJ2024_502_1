using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Ken : MonoBehaviour
{
    private Animator _animator;

    [SerializeField]
    private float _velocidad = 5;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float velocidadActual = horizontal * _velocidad * Time.deltaTime; 
        transform.Translate(
            velocidadActual,
            0,
            0
        );
        _animator.SetFloat("velocidad", velocidadActual);

        if(Input.GetButton("Jump"))
        {
            _animator.SetTrigger("hadouken");
        }
    }
}

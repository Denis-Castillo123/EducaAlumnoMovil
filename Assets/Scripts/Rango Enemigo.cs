using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoEnemigo : MonoBehaviour
{
    public Animator animator;
    public ChelinesM chelines;
    public GameObject target;

    void Start()
    {
        // Busca el objeto Barron-Animado una vez al inicio y almacenalo en la variable target.
        target = GameObject.Find("Profesor");
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Verifica si el objeto que colisiono es el mismo que se encuentra en la variable target.
        if (coll.gameObject == target)
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
            animator.SetBool("attack", true);
            GetComponent<BoxCollider2D>().enabled = false;
            //Debug.Log("Atacado");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Puedes realizar otras acciones en el Update si es necesario.
    }
}

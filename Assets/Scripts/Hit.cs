using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D coll){
        if(coll.CompareTag("Barron-Animado"))
        {
            print("Daño");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

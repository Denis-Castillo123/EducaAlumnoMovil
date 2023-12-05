using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{

    public GameObject Barron;

    // LateUpdate se llama después de Update en cada frame
    void LateUpdate()
    {
        Vector3 position = transform.position;
        position.x = Barron.transform.position.x;
        transform.position = position;
    }
}

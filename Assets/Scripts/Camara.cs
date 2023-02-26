using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject personaje;

    /*Para que la camara siga al personaje de forma horizontal*/
    void Update()
    {
        if (personaje != null)
        {
            Vector3 position = transform.position;
            position.x = personaje.transform.position.x;
            transform.position = position;
        }
        
    }
}

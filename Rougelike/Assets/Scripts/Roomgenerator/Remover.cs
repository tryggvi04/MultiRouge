using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
     void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spawnpoint"))
        {

           Destroy(other.gameObject);

        }
        if (other.CompareTag("Wall"))
        {

        Destroy(other.gameObject);

        }


    }
    
    
}

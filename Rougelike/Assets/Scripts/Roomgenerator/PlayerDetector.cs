using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    
    public bool isPlayer = false;

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == ("Player"))
        {
            isPlayer = true;


        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == ("Player"))
        {
            isPlayer = false;


        }
    }

}

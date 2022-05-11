using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    Health health;
    void Start()
    {
        health = gameObject.GetComponentInChildren<Health>();
    }

    
    void Update()
    {
        Death();

    }
    void Death()
    {
        if (health.Dead == true)
        {
            Destroy(gameObject);



        }



    }
}

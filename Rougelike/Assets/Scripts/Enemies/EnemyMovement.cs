﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float Speed;
    public Transform target;
    public float minDistance = 2f;
    public Vector3 dir;
   
    
  
    
   


    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

    }


    void FixedUpdate()
    {
        dir = (target.transform.position - rb2D.transform.position).normalized;
       
        
     
        if (Vector3.Distance(rb2D.position, target.transform.position) > minDistance)
        {
            rb2D.MovePosition(rb2D.transform.position + dir * Speed * Time.fixedDeltaTime);
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private delegate void StateUpdate();

    [SerializeField]
    Rigidbody2D rb2D;
    [SerializeField]
    float Speed;
    [SerializeField]
    Transform target;
    [SerializeField]
    float minDistance = 2f;
    public Vector3 dir;
    PlayerDetector GetPlayer;

    private float chargeUpTimer;
    private float chargeUpTime;
    [SerializeField]
    private float maxChargeTime;

    [SerializeField]
    private float _test;

    void ActiveUpdate()
    {
       //Debug.Log("Active Update");
        Move();
    }

    void IdleUpdate()
    {
        //Debug.Log("Idle Update");
        CheckForPlayer();
    }

    void Awake()
    {
        gameObject.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
        GetPlayer = GetComponentInParent<PlayerDetector>();
        rb2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private StateUpdate activeUpdate;
    private StateUpdate idleUpdate;
    private StateUpdate stateUpdate;

    void Start()
    {
        activeUpdate = new StateUpdate(ActiveUpdate);
        idleUpdate = new StateUpdate(IdleUpdate);
        stateUpdate = idleUpdate;
    }


    void FixedUpdate()
    {
        stateUpdate();
    }

    void Move()
    {
        dir = Vector3.Normalize(target.transform.position - rb2D.transform.position);

        //rb2D.MovePosition();

        /*dir = Vector3.Normalize(target.transform.position - rb2D.transform.position);

        if (Vector3.Distance(rb2D.position, target.transform.position) > minDistance)
        {
            rb2D.MovePosition(rb2D.transform.position + dir * Speed * Time.fixedDeltaTime);
        }
        if (GetPlayer.isPlayer == false)
        {
            //Swap updates
            stateUpdate = idleUpdate;
        }*/
    }

    void CheckForPlayer()
    {
        if (GetPlayer.isPlayer == true)
        {
            //Swap updates
            stateUpdate = activeUpdate;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private delegate void StateUpdate();

    public Rigidbody2D rb2D;
    public float Speed;
    public Transform target;
    public float minDistance = 2f;
    public Vector3 dir;

    void ActiveUpdate()
    {
        Debug.Log("Active Update");
        Move();
    }

    void IdleUpdate()
    {
        Debug.Log("Idle Update");
        CheckForPlayer();
    }

    void Awake()
    {
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
        dir = (target.transform.position - rb2D.transform.position).normalized;

        if (Vector3.Distance(rb2D.position, target.transform.position) > minDistance)
        {
            rb2D.MovePosition(rb2D.transform.position + dir * Speed * Time.fixedDeltaTime);
        }
    }

    void CheckForPlayer()
    {
        //Temporary solution until we get the room system working
        float playerDistance = Mathf.Sqrt(Mathf.Pow(transform.position.x - target.transform.position.x, 2) + Mathf.Pow(transform.position.y - target.transform.position.y, 2));
        if (playerDistance < 7)
        {
            //Swap updates
            stateUpdate = activeUpdate;
        }
    }
}

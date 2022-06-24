using System.Collections;
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


    [SerializeField]
    private float walkSpeed = 5f;
    [SerializeField]
    private float dashForce = 20f;

    private float chargeUpTimer = 0f;
    private float chargeUpTime;
    [SerializeField]
    private float maxChargeTime = 1.5f;
    [SerializeField]
    private float minChargeTime = 1.5f;
    [SerializeField]
    private float chargeRange = 4f;
    [SerializeField]
    private float forceChargeRange = 2f;
    [SerializeField]
    private float dashTime = 1f;
    private float dashTimer = 0f;

    [SerializeField]
    private float graceTime = 1f;
    private float graceTimer = 0f;
    private Vector3 randomDir;

    [SerializeField]
    private float _test;

    void ActiveUpdate()
    {
       //Debug.Log("Active Update");
        Seek();
    }

    void IdleUpdate()
    {
        //Debug.Log("Idle Update");
        CheckForPlayer();
    }

    void ChargeUpdate()
    {
        chargeUpTimer += Time.fixedDeltaTime;
        if (chargeUpTimer > chargeUpTime)
        {
            stateUpdate = dashUpdate;
            chargeUpTimer = 0;
        }
    }

    void DashUpdate()
    {
        if (dashTimer == 0f)
        {
            rb2D.AddForce(GetDir() * dashForce, ForceMode2D.Impulse);
        }
        dashTimer += Time.fixedDeltaTime;
        if (dashTimer > dashTime)
        {
            stateUpdate = randomUpdate;
            dashTimer = 0f;
        }
    }

    void StunUpdate()
    {

    }

    void RandomUpdate()
    {
        if (graceTimer == 0f)
        {
            randomDir = GetRandomDir();
        }
        rb2D.AddForce(new Vector2(-rb2D.velocity.x, -rb2D.velocity.y));
        rb2D.AddForce(randomDir * walkSpeed);
        graceTimer += Time.fixedDeltaTime;
        if (graceTimer > graceTime)
        {
            stateUpdate = activeUpdate;
            graceTimer = 0f;
        }
    }

    void Awake()
    {

        GetPlayer = GetComponentInParent<PlayerDetector>();
        rb2D = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
    }

    private StateUpdate activeUpdate;
    private StateUpdate idleUpdate;
    private StateUpdate chargeUpdate;
    private StateUpdate dashUpdate;
    private StateUpdate stunUpdate;
    private StateUpdate stateUpdate;
    private StateUpdate randomUpdate;

    void Start()
    {
        activeUpdate = new StateUpdate(ActiveUpdate);
        idleUpdate = new StateUpdate(IdleUpdate);
        chargeUpdate = new StateUpdate(ChargeUpdate);
        dashUpdate = new StateUpdate(DashUpdate);
        stunUpdate = new StateUpdate(StunUpdate);
        randomUpdate = new StateUpdate(RandomUpdate);
        stateUpdate = idleUpdate;
    }


    void FixedUpdate()
    {
        stateUpdate();
    }

    void Seek()
    {
        dir = GetDir();

        if (Vector3.Distance(target.transform.position, transform.position) > chargeRange)
        {
            rb2D.AddForce(new Vector2(-rb2D.velocity.x, -rb2D.velocity.y));
            rb2D.AddForce(dir * walkSpeed);
        }
        else
        {
            chargeUpTime = maxChargeTime;
            stateUpdate = chargeUpdate;
        }

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

    Vector3 GetDir()
    {
        return Vector3.Normalize(target.transform.position - rb2D.transform.position);
    }

    Vector3 GetRandomDir()
    {
        return Vector3.Normalize(new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0));
    }
}

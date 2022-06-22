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
    private float dashTime = 5f;
    private float dashTimer = 0f;

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
        gameObject.transform.localScale = new Vector3(0.04f, 0.04f, 0.04f);
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
            Debug.Log("dashing");
            gameObject.transform.localScale = new Vector3(0.06f, 0.06f, 0.06f);
            rb2D.AddForce(GetDir() * dashForce, ForceMode2D.Impulse);
        }
        dashTimer += Time.fixedDeltaTime;
        if (dashTimer > dashTime)
        {
            stateUpdate = activeUpdate;
            gameObject.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            dashTimer = 0f;
        }
    }

    void StunUpdate()
    {

    }

    void RandomUpdate()
    {

    }

    void Awake()
    {
        //sorry testing without
        //gameObject.transform.localScale = new Vector3(0.07f, 0.07f, 0.07f);
        GetPlayer = GetComponentInParent<PlayerDetector>();
        rb2D = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
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
        Debug.Log("seeking");
        dir = GetDir();

        if (Vector3.Distance(target.transform.position, transform.position) > chargeRange)
        {
            //rb2D.velocity.x = 0;
            //rb2D.velocity.y = 0;
            rb2D.AddForce(dir * walkSpeed);
        }
        else
        {
            chargeUpTime = Random.Range(minChargeTime, maxChargeTime);
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
}

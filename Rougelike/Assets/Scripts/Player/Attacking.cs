using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public float AttackRange;
    public GameObject test;
    public float AttackPointRange;
    Movement Movement;
    public int Damage;
    public float AttackDelay;
    public float AttackDelayMax;
    private void Start()
    {
        Movement = gameObject.GetComponent<Movement>();
        AttackDelay = AttackDelayMax;
    }
    private void Update()
    {
        MeeleAttack();
        test.transform.localPosition = Movement.direction.normalized * AttackPointRange;
    }


    void MeeleAttack()
    {
        if (AttackDelay <= 0)
        {
            if (Input.GetButton("Attack"))
            {
                RaycastHit2D hit = Physics2D.Raycast(test.transform.position, Movement.direction, AttackRange);

                if (hit.collider != null && hit.collider.gameObject.CompareTag("Enemy"))
                {
                  
                    hit.collider.GetComponent<Health>().CurrentHealth -= Damage;
                    AttackDelay = AttackDelayMax;
                }


            }
        }
        if (AttackDelay >= 0)
        {
            AttackDelay -= Time.deltaTime;
        }

    }
}

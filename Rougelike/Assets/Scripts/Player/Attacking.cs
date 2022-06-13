using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public float AttackRange;
    public GameObject attackPoint;
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
        attackPoint.transform.localPosition = Movement.direction.normalized * AttackPointRange;
    }


    void MeeleAttack()
    {
        if (AttackDelay <= 0)
        {
            if (Input.GetButton("Attack"))
            {
                print("attacking baaboo");

                RaycastHit2D hit = Physics2D.Raycast(attackPoint.transform.position, Movement.direction, AttackRange);

                if (hit.collider != null && hit.collider.gameObject.CompareTag("Enemy"))
                {
                    print("wamo shlamo");
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

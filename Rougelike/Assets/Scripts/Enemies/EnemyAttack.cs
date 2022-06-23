using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    EnemyMovement GetMovement;
    Health health;
    public float damage = 10f;
    public float range = 1f;
    public GameObject attackPoint;
    public float AttackDelayMax;
    private float AttackDelay;
    RaycastHit2D hit2D;

    private void Awake()
    {
        GetMovement = GetComponent<EnemyMovement>();
    }

    void Update()
    {
        attackPoint.transform.localPosition = GetMovement.dir * range;
        Attack();
    }

    void Attack()
    {

        if (AttackDelay <= 0)
        {
            hit2D = Physics2D.Raycast(attackPoint.transform.position, GetMovement.dir, range);
            Debug.DrawRay(attackPoint.transform.position, GetMovement.dir, Color.red);

            if (hit2D.collider != null)
            {
                if (hit2D.collider.name == ("Player"))
                {
                    health = hit2D.collider.gameObject.GetComponent<Health>();
                   health.TakeDamage(damage);
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

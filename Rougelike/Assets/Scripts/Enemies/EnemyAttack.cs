using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    EnemyMovement GetMovement;
    Health health;
    public float damage = 10f;
    public float range = 10f;
    public GameObject attackPoint;
    public float AttackDelayMax;
    private float AttackDelay;

    private void Awake()
    {
        GetMovement = GetComponent<EnemyMovement>();
    }

    void Update()
    {
        attackPoint.transform.localPosition = GetMovement.dir.normalized * range;
        Attack();
    }

    void Attack()
    {

        if (AttackDelay <= 0)
        {
            RaycastHit2D hit2D = Physics2D.Raycast(attackPoint.transform.position, GetMovement.dir, range);

            if (hit2D.collider != null)
            {
                //print(hit2D.collider.tag);

            }
            if (hit2D.collider.name == ("Player"))
            {
                health = hit2D.collider.GetComponent<Health>();
                health.CurrentHealth -= damage;
                //print("hello");
                AttackDelay = AttackDelayMax;
            }
            
        }
        if (AttackDelay >= 0)
        {
            AttackDelay -= Time.deltaTime;
        }

        
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public float AttackRange;
    [SerializeField]
    private GameObject attackPoint;
    [SerializeField]
    private GameObject attackHitbox;
    public float AttackPointRange;
    Movement Movement;
    public int Damage;
    public float AttackDelay;
    public float AttackDelayMax;
    private PlayerAttackColliderCache colScript;
    

    private void Start()
    {
        colScript = gameObject.GetComponentInChildren<PlayerAttackColliderCache>();
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
                Debug.Log("attacking " + AttackDelay);
                AttackDelay = AttackDelayMax;
                for (int i = 0; i < colScript.colCache.Length; i++)
                {
                    if (colScript.colCache[i].tag == "Enemy")
                    {
                        colScript.colCache[i].GetComponent<Health>().TakeDamage(Damage);
                    }
                }


                //eventually delete, keeping for rollback if needed
                /*RaycastHit2D hit = Physics2D.Raycast(attackPoint.transform.position, Movement.direction);

                if (hit.collider != null && hit.collider.gameObject.CompareTag("Enemy"))
                {
                    hit.collider.GetComponent<Health>().CurrentHealth -= Damage;
                    AttackDelay = AttackDelayMax;
                }*/
            }
        }
        if (AttackDelay >= 0)
        {
            AttackDelay -= Time.deltaTime;
        }
    }
}

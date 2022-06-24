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

    [HideInInspector]
    public Collider2D[] colCache;


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
        //Debug.Log("1 " + colCache.Length);
        if (AttackDelay <= 0)
        {
            if (Input.GetButton("Attack"))
            {
                Debug.Log(colCache.Length);
                for (int i = 0; i < colCache.Length; i++)
                {
                    //Debug.Log(colCache[i].gameObject.name + " , " + i);
                }
                AttackDelay = AttackDelayMax;
                Debug.Log("starting attack queued " + colCache.Length + " attacks");
                for (int i = 0; i < colCache.Length; i++)
                {
                    Debug.Log("attacking " + colCache[i].gameObject.name);
                    if (colScript.colCache[i].CompareTag("Enemy"))
                    {
                        colCache[i].GetComponent<Health>().TakeDamage(Damage);
                    }
                }
                AttackDelay = AttackDelayMax;


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

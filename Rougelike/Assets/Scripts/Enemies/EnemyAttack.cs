using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    EnemyMovement GetMovement;
    Health health;
    public float damage = 10f;
    public float range = 10f;

    private void Awake()
    {
        GetMovement = GetComponent<EnemyMovement>();
    }

    void Update()
    {
        Attack();
    }

    void Attack()
    {
        
        
            RaycastHit2D hit2D = Physics2D.Raycast(gameObject.transform.position, Vector2.left, range);
        Debug.DrawLine(gameObject.transform.position, Vector2.left, color: Color.blue);
        if (hit2D.collider != null)
        {
            print(hit2D.collider.name);

        }   
        if (hit2D.collider == GameObject.FindGameObjectWithTag("Player"))
            {
                health = hit2D.collider.GetComponent<Health>();
                health.CurrentHealth -= damage;
            print("hello");

            }



        


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerCache : MonoBehaviour
{
    [HideInInspector]
    public bool playerTouching = false;

    Health health;
    public float damage = 10f;
    public float AttackDelayMax;
    private float AttackDelay;
    GameObject player;
    Health playerHealth;

    private void Awake()
    {
        player = GameObject.Find("Player");
        playerHealth = player.gameObject.GetComponent<Health>();
    }

    void Update()
    {
        if (playerTouching)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerTouching = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerTouching = false;
        }
    }
}

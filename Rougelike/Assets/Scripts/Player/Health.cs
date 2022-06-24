using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
     private Slider HealthBar;
    public float CurrentHealth;
    public float MaxHealth;
   public bool Dead = false;
    EnemyGenerator GetEnemy;


    //only for player
    [SerializeField]
    private bool Player;
    [SerializeField]
    private float Iframes;
    [SerializeField]
    private float Iframes_Timer;


    void Awake()
    {
        if (gameObject.name == "Player")
        {
            Player = true;
        }
        CurrentHealth = MaxHealth;
        HealthBar = gameObject.GetComponentInChildren<Slider>();
        if (Player == false)
        {
            GetEnemy = GetComponentInParent<EnemyGenerator>();
        }
    }


    void Update()
    {
        Iframes -= Time.deltaTime;
        HealthBar.value = CurrentHealth/MaxHealth;
        if (CurrentHealth <= 0)
        {
            Dead = true;
        }
    }

    public void TakeDamage(float amount)
    {

        if (Player == true)
        {
           if (Iframes <= 0)
            {
                CurrentHealth -= amount;
                Iframes = Iframes_Timer;
            }

        }
        else{

            CurrentHealth -= amount;
        }
    }

}

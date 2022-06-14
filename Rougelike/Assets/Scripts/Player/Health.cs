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
    
    void Awake()
    {
        CurrentHealth = MaxHealth;
        HealthBar = gameObject.GetComponentInChildren<Slider>();
        if (gameObject.name != ("Player"))
        {
            GetEnemy = GetComponentInParent<EnemyGenerator>();
        }
    }

    
    void Update()
    {
        HealthBar.value = CurrentHealth/MaxHealth;
        if (CurrentHealth <= 0)
        {
            
            Dead = true;
            

        }
    }
    
}

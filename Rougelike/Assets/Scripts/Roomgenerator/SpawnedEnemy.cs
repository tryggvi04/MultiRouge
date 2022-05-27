using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedEnemy : MonoBehaviour
{
    private EnemyGenerator template;

    void Start()
    {
        template = GetComponentInParent<EnemyGenerator>();
        template.EnemiesLeft.Add(this.gameObject);
    }
}

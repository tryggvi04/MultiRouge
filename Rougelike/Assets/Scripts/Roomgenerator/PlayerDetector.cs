using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    
    public bool isPlayer = false;
    private bool wallSpawned = false;
    //prefab of the wall
    public GameObject WallsPrefab;
    public GameObject wall;
    EnemyGenerator enemyGen;
    private void Awake()
    {
        enemyGen = GetComponent<EnemyGenerator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == ("Player"))
        {
            isPlayer = true;


        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == ("Player"))
        {
            isPlayer = false;


        }
    }
    private void FixedUpdate()
    {
        if (isPlayer == true && wallSpawned == false)
        {
          wall = Instantiate(WallsPrefab, gameObject.transform.position, gameObject.transform.rotation, transform.root);

            wallSpawned = true;
            

        }
        //temporary until we have a better boss system
        if (GetComponent<EnemyGenerator>() != null)
        {
            if (enemyGen.EnemiesLeft.Count == 0)
            {
                Destroy(wall);


            }
        }
    }

}

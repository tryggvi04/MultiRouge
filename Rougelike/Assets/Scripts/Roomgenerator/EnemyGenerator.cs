using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
   

    private int rand;
    RoomTemplate templates;
    private bool spawned = false;
    public int maxEnemies = 0;
    public List<GameObject> EnemiesLeft;
    // how many enemies should spawn
    public int enemiesCount;
    private int maxEnemiesSpawn = 4;


    void Start()
    {

        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("Spawn", 0.1f);
    }






    void Spawn()
    {

        if (spawned == false)
        {
            enemiesCount = Random.Range(1, maxEnemiesSpawn);
            for (int i = 0; i < enemiesCount; i++)
            {
                rand = Random.Range(0, maxEnemies);
                Instantiate(templates.easyEnemies[rand], transform.position, templates.easyEnemies[rand].transform.rotation, gameObject.transform);
            }
               
            
        }



        spawned = true;
    }


}

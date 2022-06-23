using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{


    private int rand;
    private int spawnX;
    private int spawnY;
    RoomTemplate templates;
    public int maxEnemies = 0;
    public List<GameObject> EnemiesLeft;
    // how many enemies should spawn
    public int enemiesCount;
    private int maxEnemiesSpawn = 4;
    private GameObject Enemy;


    void Start()
    {

        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("Spawn", 0.1f);
    }

    private void Update()
    {
        EnemiesLeft.RemoveAll(s => s == null);
    }




    void Spawn()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        enemiesCount = Random.Range(1, maxEnemiesSpawn);
            for (int i = 0; i < enemiesCount; i++)
            {              
                rand = Random.Range(0, maxEnemies);
                spawnX = Random.Range(-3, 3);
                spawnY = Random.Range(-3, 3);
           Enemy = Instantiate(templates.easyEnemies[rand], gameObject.transform, true);
            Enemy.transform.position = transform.position + new Vector3(spawnX, spawnY, 0);
        }
    }


}

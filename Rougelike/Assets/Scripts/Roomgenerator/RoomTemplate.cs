using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] easyEnemies;
    public GameObject bottomRoom;
    public GameObject topRoom;
    public GameObject leftRoom;
    public GameObject rightRoom;
    public GameObject closedRoom;
    public List<GameObject> rooms;
    public float waitTime;
    private bool spawnedBoss;
    public GameObject Boss;
    
     void Update()
    {
        if (waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                   Instantiate(Boss, rooms[i].transform.position, Quaternion.identity);
                   Destroy(rooms[i]);
                    spawnedBoss = true;

                }
            }


        }
        else
        {
            waitTime -= Time.deltaTime;

        }
       
       }
  
}

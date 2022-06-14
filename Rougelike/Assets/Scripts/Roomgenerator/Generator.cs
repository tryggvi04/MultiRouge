using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator: MonoBehaviour
{
    public int openingDirection;
    // 1 = Bottom
    // 2 = Top
    // 3 = Left
    // 4 = Right

    // how many rooms should it generate
    public int MaxRooms = 8;
    private int rand;
    private RoomTemplate templates;
    private bool spawned = false;
    public float waitTime = 10f;
   
  
  
   
    void Start()
    {

      Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("Spawn", 0.1f);
    }






    void Spawn()
    {
        if (templates.rooms.Count <= MaxRooms)
        {
            if (spawned == false)
            {
                if (openingDirection == 1)
                {
                    // need Bottom
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);


                }
                else if (openingDirection == 2)
                {
                    // need Top
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);

                }
                else if (openingDirection == 3)
                {
                    // need Left
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);

                }
                else if (openingDirection == 4)
                {
                    // need Right
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);

                }
            }



            spawned = true;
        }
        if (templates.rooms.Count >= MaxRooms)
        {
            if (spawned == false)
            {
                if (openingDirection == 1)
                {
                    // need Bottom
                  
                    Instantiate(templates.bottomRooms[0], transform.position, templates.bottomRooms[0].transform.rotation);


                }
                else if (openingDirection == 2)
                {
                    // need Top
                 ;
                    Instantiate(templates.topRooms[0], transform.position, templates.topRooms[0].transform.rotation);

                }
                else if (openingDirection == 3)
                {
                    // need Left
                    
                    Instantiate(templates.leftRooms[0], transform.position, templates.leftRooms[0].transform.rotation);

                }
                else if (openingDirection == 4)
                {
                    // need Right
                   
                    Instantiate(templates.rightRooms[0], transform.position, templates.rightRooms[0].transform.rotation);

                }
            }



            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Spawnpoint"))
        {
            if (other.GetComponent<Generator>().spawned == false && spawned==false)
            {
                // wall
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            


            spawned = true;


        }

       

    }
}



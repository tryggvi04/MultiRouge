using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedRooms : MonoBehaviour
{
    private RoomTemplate template;

     void Start()
    {
        template = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        template.rooms.Add(this.gameObject);
    }
}

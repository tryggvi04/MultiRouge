using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackColliderCache : MonoBehaviour
{
    [HideInInspector]
    public Collider2D[] colCache;

    void Start()
    {
        colCache = new Collider2D[1];
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        for (int i = 0; i < colCache.Length; i++)
        {
            if (colCache[i] == null)
            {
                colCache[i] = col;
                break;
            }
        }

        Collider2D[] temp = new Collider2D[colCache.Length + 1];
        colCache.CopyTo(temp, 0);
        colCache = temp;

        colCache[colCache.Length - 1] = col;
        Debug.Log("Collision ENTER " + col.gameObject.name);
    }

    void OnTriggerExit2D(Collider2D col)
    {
        for(int i = 0; i < colCache.Length; i++)
        {
            if (colCache[i] == col && col.gameObject.tag == "Enemy")
            {
                colCache[i] = null;
                break;
            }
        }
        Debug.Log("Collision EXIT " + col.gameObject.name);
    }
}

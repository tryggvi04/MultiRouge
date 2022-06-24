using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackColliderCache : MonoBehaviour
{
    [HideInInspector]
    public Collider2D[] colCache;

    private Attacking attackScript;

    void Start()
    {
        attackScript = gameObject.GetComponentInParent<Attacking>();
        colCache = new Collider2D[1];
    }

    void Update()
    {
        /*for (int i = 0; i < colCache.Length; i++)
        {
            Debug.Log(colCache[i].gameObject.name + " , " + i);
        }*/

        attackScript.colCache = colCache;

        //colCache = new Collider2D[0];
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        bool breakOut = false;

        for (int i = 0; i < colCache.Length; i++)
        {
            if (colCache[i] == col)
            {
                breakOut = true;
                break;
            }
        }
        if (breakOut)
        {
            return;
        }
        for (int i = 0; i < colCache.Length; i++)
        {
            if (colCache[i] == null)
            {
                colCache[i] = col;
                breakOut = true;
                break;
            }
        }
        if (breakOut)
        {
            return;
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
            if (colCache[i] == col)
            {
                colCache[i] = null;
                break;
            }
        }
        Debug.Log("Collision EXIT " + col.gameObject.name);
    }
}

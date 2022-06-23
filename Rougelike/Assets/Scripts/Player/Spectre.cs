using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectre : MonoBehaviour
{
    private delegate void StateUpdate();
    private StateUpdate physical_World;
    private StateUpdate spectre_World;
    private StateUpdate stateUpdate;
    [SerializeField]
    private GameObject Physical_World_Camera;
    [SerializeField]
    private GameObject Spectre_World_Camera;

    void Start()
    {
        physical_World = new StateUpdate(Physical_World);
        spectre_World = new StateUpdate(Spectre_World);
        stateUpdate = physical_World;
    }

    private void FixedUpdate()
    {
        stateUpdate();
    }
    void Physical_World()
    {
        gameObject.layer = LayerMask.NameToLayer("Physical_World");
        Physical_World_Camera.SetActive(true);
        Spectre_World_Camera.SetActive(false);
        if (Input.GetButtonDown("Realm_Change"))
        {
            stateUpdate = spectre_World;


        }

    }
    void Spectre_World()
    {
        gameObject.layer = LayerMask.NameToLayer("Spectre_World");
        Physical_World_Camera.SetActive(false);
        Spectre_World_Camera.SetActive(true);
        if (Input.GetButtonDown("Realm_Change"))
        {
            stateUpdate = physical_World;


        }

    }

}

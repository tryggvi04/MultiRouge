using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeadText : MonoBehaviour
{
    TMP_Text deadText;
    Health healthScript;

    private void Awake()
    {
        deadText = gameObject.GetComponent<TMP_Text>();
        healthScript = gameObject.GetComponentInParent<Health>();
        deadText.enabled = false;
    }

    private void Update()
    {
        if (healthScript.Dead)
        {
            deadText.enabled = true;
        }
    }

}

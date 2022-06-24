using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Sprites;
using TMPro;

public class Movement : MonoBehaviour
{
    public int Speed;
    Vector2 playerInputWalk;
    Vector2 playerInputDash;
    private Rigidbody2D rb;
    public int dashLenght;
    public int dashDelay;
    public float dashTimer = 0;
    public bool canWalk = true;
    public float dashTime;
    public TextMeshProUGUI DelayText;
    public Vector2 direction;
    private Health health;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
    }


    void FixedUpdate()
    {
        Dash();
        Walk();
    }
    void Walk()
    {
        if (canWalk == true)
        {
            playerInputWalk = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * Speed;
            rb.AddForce(playerInputWalk);
            if (rb.velocity != new Vector2(0, 0))
            {
                direction = rb.velocity;
            }
            rb.velocity = new Vector2(0, 0);
        }
    }
    void Dash()
    {

        playerInputDash = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * dashLenght;
        if (playerInputDash != new Vector2(0, 0))
        {

            if (dashTimer <= 0)
            {
                if (Input.GetButtonDown("Dash"))
                {

                    canWalk = false;
                    rb.AddForce(playerInputDash);
                    dashTimer = dashDelay;

                }


            }


        }
        if (dashTimer <= dashDelay - dashTime)
        {
            canWalk = true;


        }
        if (dashTimer >= 0)
        {
            dashTimer -= Time.deltaTime;

        }

        DelayText.text = Mathf.Round(dashTimer).ToString("");
    }

}

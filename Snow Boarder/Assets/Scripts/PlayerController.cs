using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public bool canMove=true;
    [SerializeField] float torqueAmount=1;

    [SerializeField] float boostSpeed=370f;
    [SerializeField] float baseSpeed=28f;
    SurfaceEffector2D surfaceEffector2D;


    // Start is called before the first frame update
    public void Start()
    {
        rb2d= GetComponent<Rigidbody2D>();
        surfaceEffector2D=FindObjectOfType<SurfaceEffector2D>();
    }
    public void DisableControls()
    {
        canMove=false;
    }
    // Update is called once per frame
    public void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
      
    }

     void RespondToBoost()
    {
        if(Input.GetKey(KeyCode.Space))
        {
                surfaceEffector2D.speed=boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed=baseSpeed;
        }
     }

     void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }
}

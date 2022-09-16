using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementDeneme : MonoBehaviour
{
    [Header("degerler")]
    [SerializeField] float Speed;
    [SerializeField] float JumpSpeed;
    [SerializeField] MainTimeControl timeController;
    [SerializeField] int whichTime = 0;
    float ourTime;    


    Rigidbody2D Rb2d;
    Vector2 Movement;
    bool IsOnGround = false;
    int JumpRight = 2;


    
    void Start()
    {
        Rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ourTime = timeController.times[whichTime];

        MovementFunction();
        GetKeyEvents();
    }

    void GetKeyEvents()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            Jump();

        }

    }
    

    void MovementFunction()
    {
        Rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed * ourTime, Rb2d.velocity.y);


    }

    void Jump()
    {

        if (JumpRight > 1)
        {
            Rb2d.velocity = new Vector2(Rb2d.velocity.x, JumpSpeed);
            JumpRight--;

        }
       

    }

    public void OnLand()
    {

        IsOnGround = true;
        JumpRight = 2;
    }

    public void OnAir()
    {

        IsOnGround = false;

    }

    public void OnWall()
    {
        JumpRight = 2;

    }

}

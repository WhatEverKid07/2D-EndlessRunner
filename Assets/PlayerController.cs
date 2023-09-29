using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Create a referance to the Rigidbody2D so we can manipulate it 
    Rigidbody2D playerObject;
    public GameObject groundChecker;
    public LayerMask whatisground;
    public float jumpSpeed = 8.0f;
    bool jumping = false;
    public float maxSpeed = 5.0f;
    bool isOnGround = true;
    float jumpTime;
    public float buttonTime = 0.3f;

   

    // Start is called before the first frame update
    void Start()
    {
      

       //Fined the Rigibody2D component that is attached to the same object as this script
       playerObject = GetComponent<Rigidbody2D>();
      
       

    }

    // Update is called once per frame
    void Update()
    {
        //Create a 'float' that will equal to the players horizontal input

        float movementValueX = Input.GetAxis("Horizontal");


        //Change the X velocity of the Rigidboady2D to be equal to the movement value
        playerObject.velocity = new Vector2(movementValueX * 10, playerObject.velocity.y);


        //Check to see if the ground object is touching the ground
        
        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 1.0f, whatisground);

        if (Input.GetButtonDown("Jump"))
        {
            playerObject.velocity = new Vector2(playerObject.velocity.x, jumpSpeed);

            jumping = true;
            jumpTime = 0;
        }

        if(jumping)
        {
            jumpTime += Time.deltaTime;
        }

        if (Input.GetButtonDown("Space") | jumpTime > buttonTime)
        {
            jumping = false;
        }

    }



}
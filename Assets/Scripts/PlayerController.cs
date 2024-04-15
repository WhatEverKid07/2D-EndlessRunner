using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    AudioManager audioManager;
    Vector2 vecGravity;

    public float speed;
    public float jumpSpeed;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public Animator animator;
    public Transform CoinScore;

    private Rigidbody2D playerObject;
    private bool isTouchingGround;
    private float direction = 1f;
    private int coinScore = 0; 
    private bool isJumping;
    private float jumpCounter;

    [Header("Jump System")]
    [SerializeField] float fallMultiplier;
    [SerializeField] float jumpMultiplier;
    [SerializeField] float jumpTime;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        playerObject = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetFloat("speed", direction);

        
        if(direction > 0f)
        {
            playerObject.velocity = new Vector2(direction * speed, playerObject.velocity.y);
        }
        else if (direction < 0f)
        {
            playerObject.velocity = new Vector2(direction * speed, playerObject.velocity.y);
        }
        else
        {
            playerObject.velocity = new Vector2(0, playerObject.velocity.y);
        }



        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            playerObject.velocity = new Vector2(playerObject.velocity.x, jumpSpeed);
            isJumping = true;
            jumpCounter = 0;
            isTouchingGround = false;
            
        }
        
        if (playerObject.velocity.y>0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if(jumpCounter > jumpTime) isJumping = false;

            playerObject.velocity += vecGravity * jumpMultiplier * Time.deltaTime;
        }


        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            animator.SetBool("isJumping", true);
        }

        if (isTouchingGround == true)
        {
           animator.SetBool("isJumping", false);
        }

        if (isTouchingGround == false)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isTouchingGround", false);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            coinScore += 5;
            Debug.Log(coinScore);
            collision.gameObject.SetActive(false);
        }

        if (collision.tag == "VendingMachine")
        {
            coinScore += 15;
            Debug.Log(coinScore);
        }

    }


}
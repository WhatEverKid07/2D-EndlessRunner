using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class Key
{
    public KeyCode keyCode;
}
public class PlayerController : MonoBehaviour
{
    Vector2 vecGravity;

    public List<Key> keys = new List<Key>();

    public float speed;
    public float jumpSpeed;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public Animator animator;
    public Text coinScoreText;

    public static int coinScoreStatic;

    public AudioSource jump;
    public AudioSource coinCollection;
    public AudioSource running;
    public AudioSource vendingMachineExplosion;

    private Rigidbody2D playerObject;
    private bool isTouchingGround;
    private float direction = 1f;
    private int coinScore = 1;
    private bool isJumping;
    private float jumpCounter;

    [Header("Jump System")]
    [SerializeField] float fallMultiplier;
    [SerializeField] float jumpMultiplier;
    [SerializeField] float jumpTime;
    /*
    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    */
    void Start()
    {
        running.Play();
        vecGravity = new Vector2(0, -Physics2D.gravity.y);
        playerObject = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetFloat("speed", direction);


        if (direction > 0f)
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


        foreach (Key key in keys)
        {
            if (Input.GetKeyDown(key.keyCode) && isTouchingGround)
            {
                jump.Play();
                running.Pause();
                playerObject.velocity = new Vector2(playerObject.velocity.x, jumpSpeed);
                isJumping = true;
                jumpCounter = 0;
                isTouchingGround = false;
            }
            if (Input.GetKeyUp(key.keyCode))
            {
                isJumping = false;
                animator.SetBool("isJumping", true);
            }
        }


        if (playerObject.velocity.y > 0 && isJumping)
        {
            jumpCounter += Time.deltaTime;
            if (jumpCounter > jumpTime) isJumping = false;

            playerObject.velocity += vecGravity * jumpMultiplier * Time.deltaTime;
        }


        if (isTouchingGround == true)
        {
            animator.SetBool("isJumping", false);
            running.UnPause();
        }

        if (isTouchingGround == false)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isTouchingGround", false);
        }
        coinScoreStatic = coinScore;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin")
        {
            coinCollection.Play();
            coinScore += 5;
            coinScoreText.text = coinScore.ToString();
            Debug.Log(coinScore);
            collision.gameObject.SetActive(false);
        }

        if (collision.tag == "VendingMachine")
        {
            vendingMachineExplosion.Play();
            coinScore += 15;
            coinScoreText.text = coinScore.ToString();
            Debug.Log(coinScore);
        }
    }
}
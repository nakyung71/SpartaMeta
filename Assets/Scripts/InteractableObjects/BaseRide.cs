using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRide : MonoBehaviour
{

    [SerializeField] PlayerController playerObject;
    
    Rigidbody2D rb;
    Rigidbody2D playerRigidBody;
    SpriteRenderer sheepSpriteRenderer;
    SpriteRenderer playerSpriteRenderer;
    Animator playerAnimator;
    IRidable ridable;


    Vector2 moveDirection = Vector2.zero;
    protected float speed = 10f;
    private bool IsSafe = true;



    public virtual void Init()
    {
        
        rb = GetComponent<Rigidbody2D>();
        playerRigidBody=playerObject.GetComponent<Rigidbody2D>();
        playerRigidBody.bodyType = RigidbodyType2D.Kinematic;
        sheepSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        playerSpriteRenderer = playerObject.GetComponentInChildren<SpriteRenderer>();
        playerAnimator = playerObject.GetComponentInChildren<Animator>();
        playerAnimator.SetBool("IsWalk", false);
        ridable = GetComponent<IRidable>();
    }

   
    void Update()
    {
        Move(playerObject);
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (IsSafe)
            {
                ridable.GetOff();
                playerRigidBody.bodyType = RigidbodyType2D.Dynamic;
            }
            else
            {
                return;
            }

        }
    }

    private void FixedUpdate()
    {
        rb.position = rb.position + moveDirection * speed * Time.fixedDeltaTime;
    }

    void Move(PlayerController player)
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(horizontal, vertical).normalized;

        if (moveDirection.x < 0)
        {
            
            sheepSpriteRenderer.flipX = false;
            playerSpriteRenderer.flipX = false;

        }
        else if (moveDirection.x > 0)
        {
            sheepSpriteRenderer.flipX = true;
            playerSpriteRenderer.flipX = true;
        }
        else { }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("안전하지 않은 구역");
        if (collision.CompareTag("Ground"))
        {
            IsSafe = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Debug.Log("안전한 구역");
            IsSafe = true;
        }
    }

}

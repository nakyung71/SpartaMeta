using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseRide : MonoBehaviour
{

    [SerializeField] PlayerController playerObject;
    
    Rigidbody2D rb;
    SpriteRenderer sheepSpriteRenderer;
    SpriteRenderer playerSpriteRenderer;
    Animator playerAnimator;
    IRidable ridable;


    Vector2 moveDirection = Vector2.zero;
    protected float speed = 10f;




    public virtual void Init()
    {
        
        rb = GetComponent<Rigidbody2D>();
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
            ridable.GetOff();
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

  
}

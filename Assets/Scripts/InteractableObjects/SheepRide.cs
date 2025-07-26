using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepRide : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] PlayerController playerObject;
    
    Rigidbody2D rb;
    Vector2 moveDirection = Vector2.zero;
    float speed = 10f;
    SpriteRenderer sheepSpriteRenderer;
    [SerializeField] SpriteRenderer playerSpriteRenderer;


    

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        sheepSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        playerSpriteRenderer = playerObject.GetComponentInChildren<SpriteRenderer>();
    }

   
    void Update()
    {
        Move(playerObject);
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

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;




public class PlayerController : MonoBehaviour
{
    //일단 플레이어의 포지션을 가져와야되나?
    //뭐가 필요할까

    public float movespeed = 7f;
    public Vector2 moveDirection = Vector2.zero;

    Rigidbody2D rigidbody;
    CapsuleCollider2D capsuleCollider;
    Animator animator;
    SpriteRenderer spriteRenderer;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        animator=GetComponentInChildren<Animator>();
        spriteRenderer=GetComponentInChildren<SpriteRenderer>();

    }
    private void Update()
    {
        Move();
    }
    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position+moveDirection*movespeed*Time.fixedDeltaTime);
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(horizontal, vertical).normalized;


        if (moveDirection != Vector2.zero)
        {
            animator.SetBool("IsWalk", true);
        }
        else
        {
            animator.SetBool("IsWalk", false);
        }

        if(moveDirection.x<0)
        {
            spriteRenderer.flipX = false;
        }
        else if(moveDirection.x>0)
        {
            spriteRenderer.flipX=true;
        }
        else
        {

        }
    }

}

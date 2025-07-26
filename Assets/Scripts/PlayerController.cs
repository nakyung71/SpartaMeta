using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.EventSystems;




public class PlayerController : MonoBehaviour
{
    public float movespeed = 7f;
    public Vector2 moveDirection = Vector2.zero;

    Rigidbody2D rb;

    
    SpriteRenderer spriteRenderer;
    Animator animator;
    RuntimeAnimatorController runtimeAnimatorController;
    GameObject playerPrefab;


    [SerializeField] CostumeData catCostume;
    [SerializeField] CostumeData humanCostume;


    private GameObject currentCostume;

    private GameObject lastTriggeredObject;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        

        WearCostume(catCostume);
        
        
    }

    private void Update()
    {

        Move(animator, spriteRenderer);

        if (Input.GetKeyDown(KeyCode.E)&&lastTriggeredObject!=null)
        {
            IInteractable interactable = lastTriggeredObject.GetComponent<IInteractable>();
            interactable?.Interact();
        }
    }
    public void ChangeCat()
    {
        WearCostume(catCostume);
    }

    public void ChangeHuman()
    {
        WearCostume(humanCostume);
    }


    public void WearCostume(CostumeData costume)
    {
        if(currentCostume!=null)
        {
            Destroy(currentCostume);
        }

        GameObject model = Instantiate(costume.modelPrefab, transform);
        model.SetActive(true);
        currentCostume = model;

        spriteRenderer = model.GetComponentInChildren<SpriteRenderer>();
        animator = model.GetComponentInChildren<Animator>();
        
        playerPrefab =costume.modelPrefab;
        animator.runtimeAnimatorController=costume.animatorController;
        spriteRenderer.sprite = costume.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lastTriggeredObject=collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject==lastTriggeredObject)
        {
            lastTriggeredObject=null;
        }
    }
  

    private void FixedUpdate()
    {
        rb.position=rb.position+moveDirection*movespeed*Time.fixedDeltaTime;
    }

    public void Move(Animator animator,SpriteRenderer spriteRenderer)
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

    //
   

}

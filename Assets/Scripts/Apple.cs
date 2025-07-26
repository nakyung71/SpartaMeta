using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Apple : MonoBehaviour,IInteractable
{
    // Start is called before the first frame update
    CircleCollider2D circleCollider;
    SpriteRenderer spriteRenderer;
    bool isInteract = false;
    [SerializeField] PlayerController playerController;

    private void Start()
    {
        circleCollider=GetComponent<CircleCollider2D>();
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    public void Interact()
    {
        playerController.ChangeCat();
    }
}

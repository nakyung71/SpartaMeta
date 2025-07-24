using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCController : MonoBehaviour
{
    private bool isInteract;
    void Start()
    {
        GetComponentInChildren<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isInteract= false;
        }
    }

    private void Update()
    {
        if (isInteract&& Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("TheStack");
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Apple : MonoBehaviour,IInteractable
{
    
    [SerializeField] PlayerController playerController;

    public void Interact()
    {
        playerController.ChangeCat();
    }
}

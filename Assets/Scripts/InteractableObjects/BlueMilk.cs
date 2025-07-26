using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMilk : MonoBehaviour, IInteractable
{
    [SerializeField] PlayerController playercontroller;
    public void Interact()
    {
        playercontroller.ChangeHuman();
    }
}

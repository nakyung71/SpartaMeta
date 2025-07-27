using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour,IInteractable,IRidable
{
    [SerializeField] Transform playerTransform;
    [SerializeField] PlayerController playerController;
    [SerializeField] SheepRide sheepRide;
    
   
    
    public void Interact()
    {
       
        Ride();
    }

    public void Ride()
    {
        playerController.enabled = false;
        sheepRide.enabled = true;
        playerTransform.SetParent(this.transform, false);
        playerTransform.localPosition = Vector3.up;
        playerTransform.localRotation = Quaternion.identity;
        playerController.GetComponent<Rigidbody2D>().isKinematic = true;
        sheepRide.Init();
        
    }
    public void GetOff()
    {
        playerTransform.localPosition = new Vector3(0, -0.05f, 0);
        playerController.enabled = true;
        sheepRide.enabled = false;
    }
}

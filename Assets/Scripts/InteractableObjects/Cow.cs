using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour, IInteractable, IRidable
{
    [SerializeField] Transform playerTransform;
    [SerializeField] PlayerController playerController;
    [SerializeField] CowRide cowRide;



    public void Interact()
    {

        Ride();
    }

    public void Ride()
    {
        playerController.enabled = false;
        cowRide.enabled = true;
        playerTransform.SetParent(this.transform, false);
        playerTransform.localPosition = new Vector3(0.1f, 0.5f, 0);
        playerTransform.localRotation = Quaternion.identity;
        
        cowRide.Init();

    }
    public void GetOff()
    {
        playerTransform.localPosition = new Vector3(0, -0.05f, 0);
        playerController.enabled = true;
        cowRide.enabled = false;
    }
}


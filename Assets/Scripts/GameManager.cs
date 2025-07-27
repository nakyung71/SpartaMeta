using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    // Start is called before the first frame update

    private void Awake()
    {
        BaseRide[] allRides = FindObjectsOfType<BaseRide>();
        foreach (var ride in allRides)
        {
            ride.enabled = false;
        }
    }
    

    
}

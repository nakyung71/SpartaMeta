using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] SheepRide sheepRide;
    // Start is called before the first frame update
    void Start()
    {
        sheepRide.enabled = false;
    }

    
}

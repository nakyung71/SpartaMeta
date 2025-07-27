using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] SheepRide sheepride;
    private BaseRide baseRide;
    // Start is called before the first frame update

    private void Awake()
    {
        baseRide = sheepride;
        baseRide.enabled = false;
    }
    void Start()
    {
        
    }

    
}

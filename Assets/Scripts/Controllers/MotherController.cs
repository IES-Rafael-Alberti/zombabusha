using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherController : MonoBehaviour
{
    [SerializeField] private float MaxEnergy;
    [SerializeField] private float MaxRage;
    
    private float _energy; //Rubus (Mother HP)
    private float _rage; //Rubus (Related to area of search around Mother)

    private void Awake()
    {
        _energy = MaxEnergy;
        _rage = .0f;
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MotherController : NavController
{
    [SerializeField] private float MaxEnergy;
    [SerializeField] private float MaxRage;

    [SerializeField] private List<Transform> patrol;
    
    private float _energy;
    private float _rage;
    
    private int _patrolPosition;

    private void Awake()
    {
        _energy = MaxEnergy;
        _rage = .0f;
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _patrolPosition = 0;
        StartCoroutine(walkTo(patrol[_patrolPosition]));
    }

    // Update is called once per frame
    void Update()
    {
        if (!_walking)
        {
            _patrolPosition++;
            _patrolPosition %= patrol.Count;
            StartCoroutine(walkTo(patrol[_patrolPosition]));
        }
    }

}

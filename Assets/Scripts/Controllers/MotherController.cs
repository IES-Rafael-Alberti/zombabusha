using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MotherController : MonoBehaviour
{
    [SerializeField] private float MaxEnergy;
    [SerializeField] private float MaxRage;
    [SerializeField] private NavMeshAgent navAgent;

    [SerializeField] private List<Transform> patrol;
    
    private float _energy;
    private float _rage;
    
    private bool _walking;
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
    public IEnumerator walkTo(Transform destination) {
  
        if (_walking) { yield break; }

        _walking = true;
        navAgent.destination = destination.position;

        yield return new WaitUntil(() => ReachedDestinationOrGaveUp());
        _walking = false;
    }
    
    public bool ReachedDestinationOrGaveUp() {
        if (!navAgent.pathPending) {
            if (navAgent.remainingDistance <= navAgent.stoppingDistance) {
                if (!navAgent.hasPath || navAgent.velocity.sqrMagnitude == 0f) {
                    return true;
                }
            }
        }
        return false;
    }
}

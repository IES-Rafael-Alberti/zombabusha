using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavController: MonoBehaviour {
    
    [SerializeField] protected NavMeshAgent navAgent;
    
    protected bool _walking;

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

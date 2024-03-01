using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavController: MonoBehaviour {
    
    [SerializeField] protected NavMeshAgent navAgent;
    
    protected bool _walking;

    public Action<bool> endWalking = new Action<bool>((bool value) => { });

    public IEnumerator walkTo(Transform destination, bool withRotation = true) {
  
        if (_walking) { yield break; }

        _walking = true;
        navAgent.destination = destination.position;

        yield return new WaitUntil(() => ReachedDestinationOrGaveUp());

        while (withRotation && Mathf.Abs(transform.rotation.eulerAngles.y - destination.rotation.eulerAngles.y) > 5f) {
             transform.rotation = Quaternion.Slerp(transform.rotation, destination.rotation, 1.0f * Time.deltaTime);
             yield return true;
        }

        _walking = false;
        endWalking.Invoke(withRotation);
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

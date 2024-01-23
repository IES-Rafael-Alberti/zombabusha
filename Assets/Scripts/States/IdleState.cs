using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState {
    private BossController _boss;
    private bool _active;

    public IdleState(BossController boss) {
        _boss = boss;
    }

    public void Entry() {
        Debug.Log("idle state");
        _boss.StartCoroutine(InitialPause());
        _active = true;
    }

    IEnumerator InitialPause() {
        yield return new WaitForSeconds(1.0f);
        if (_active) _boss.ChangeState(States.Running);
    }

    public void Update() {
    }

    public void Exit() {
        _boss.PutTriangle();
        _active = false;
    }
}

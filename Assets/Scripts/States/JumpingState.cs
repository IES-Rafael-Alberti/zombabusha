using System.Collections;
using UnityEngine;

public class JumpingState : IState {
    private BossController _boss;
    private float _current;

    public JumpingState(BossController boss) {
        _boss = boss;
    }

    public void Entry() {
        Debug.Log("jumping!!!!");
        //_boss.StartCoroutine(Ending());
    }

    IEnumerator Ending() {
        yield return new WaitForSeconds(1.0f);
        _boss.ChangeState(States.Idle);
    }

    public void Update() {
        _current = Mathf.MoveTowards(_current, 1.0f, Time.deltaTime * 0.3f);
        if (1.0f - _current < .1f) _boss.ChangeState(States.Idle);
        _boss.transform.localScale = Vector3.one * (Mathf.PingPong(_current, 0.5f) + 1.0f);
    }

    public void Exit() {
    }
}

using System.Collections;
using UnityEngine;

public class RunningState : IState {
    private BossController _boss;

    public RunningState(BossController boss) {
        _boss = boss;
    }

    public void Entry() {
        Debug.Log("running!!!!");
        //_boss.StartCoroutine(Ending());
    }

    // IEnumerator Ending() {
    //     yield return new WaitForSeconds(1.0f);
    //     _boss.ChangeState(States.Idle);
    // }

    public void Update() {
        _boss.transform.position += new Vector3(Time.deltaTime * 2f, 0, 0);
    }

    public void Exit() {
    }
}

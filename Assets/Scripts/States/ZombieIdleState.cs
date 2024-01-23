using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieIdleState : AnimationState {
    private bool _active;

    public override void Update() {
    }

    public override void Exit() {
        base.Exit();
        _active = false;
    }


    public ZombieIdleState(string animation, Animator animator) : base(animation, animator) {
    }
}

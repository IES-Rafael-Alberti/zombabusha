using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationState : IState {
    private string _animation;
    private Animator _animator;

    public AnimationState(string animation, Animator animator) {
        _animation = animation;
        _animator = animator;
    }

    // Update is called once per frame
    public void Entry() {
        _animator.Play(_animation);
    }

    public virtual void Update() {
        
    }

    public virtual void Exit() {
        
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class BossController : MonoBehaviour {
    // Lista de estados
    private Dictionary<States, IState> stateList = new Dictionary<States, IState>();
    
    // Estados inicial y actual
    private IState _initialState;
    private IState _currentState;
    
    // Referencia al objeto que se instancia
    public GameObject triangle;
    public AnimationCurve curve;

    // Start is called before the first frame update
    void Start() {
        TriangleController.OnTriangleDestroy += PutNewTriangle;
        
        // Preparación de estados
        _initialState = new IdleState(this);
        _currentState = _initialState;
        // Añade los estados posibles a la lista
        stateList.Add(States.Idle, _initialState);
        stateList.Add(States.Running, new RunningState(this));
        stateList.Add(States.Jumping, new JumpingState(this));
        
        _currentState.Entry();
    }

    // Update is called once per frame
    void Update()
    {
        _currentState.Update();
    }

    public void ChangeState(States newState) {
        _currentState.Exit(); 
        _currentState = stateList[newState];
        _currentState.Entry();
    }

    public void PutTriangle() {
        GameObject myTriangle = Instantiate(triangle, transform);
        myTriangle.transform.parent = null;
    }

    void PutNewTriangle() {
        ChangeState(States.Idle);
    }

    private void OnMouseDown() {
        if(_currentState != stateList[States.Jumping]) ChangeState(States.Jumping);
    }
}

// Por cada estado un elemento del enum
public enum States {
    Idle, Running, Jumping
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour {
    [SerializeField] private string IntroState = "idle";
    // Lista de estados
    private Dictionary<States, IState> stateList = new Dictionary<States, IState>();
    private Animator _animator;
    private bool _intro;

    // Start is called before the first frame update
    void Start() {
        // Inicialización
        _animator = GetComponent<Animator>();
        _animator.Play("idle");
        _intro = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Detección de transiciones 
        if (_intro && _animator.GetCurrentAnimatorStateInfo(0).IsName("idle")) {
            _intro = false;
        }
    }
    
    
    
    
}

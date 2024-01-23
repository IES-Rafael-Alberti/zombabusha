using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TriangleController : MonoBehaviour {
    public static Action OnTriangleDestroy;

    public float speed;
    
    [SerializeField] private AnimationCurve _curve;

    private float _current;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (1.0f - _current < .1f) DestroyTriangle();
        _current = Mathf.MoveTowards(_current, 1.0f, Time.deltaTime * speed);
        transform.localScale = Vector3.one * _curve.Evaluate(Mathf.PingPong(_current, 0.5f));
    }

    private void OnMouseDown() {
        DestroyTriangle();
    }

    void DestroyTriangle() {
        OnTriangleDestroy?.Invoke();
        Destroy(gameObject);
    }
}

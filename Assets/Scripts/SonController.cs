using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SonController : MonoBehaviour
{
    // controls
    [SerializeField] List<GameObject> cameras;
    private int _currentCamera;
    private KeyboardInput _keyboardInput;    
    
    // data
    [SerializeField] private float MaxEnergy;
    [SerializeField] private float MaxStress;
    [SerializeField] private float StressThreshold;

    private bool _danger;
    private float _energy;
    private float _stress;

    private void Awake()
    {
        _energy = MaxEnergy;
        _stress = .0f;
        _danger = false;

        
    }

    void ChangeEnergy(float value)
    {
        _energy += value;
        Debug.Log(_energy);
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.SonEventsList[SonEvents.fall] += () => { ChangeEnergy(-5); };
        // input system init
        _keyboardInput = new KeyboardInput();
        _keyboardInput.Rooms.Enable();
        _keyboardInput.Rooms.Camera1.performed += 
            (InputAction.CallbackContext cb) => {
                SetCamera(0); 
            }; 
        _keyboardInput.Rooms.Camera2.performed += 
            (InputAction.CallbackContext cb) => {
                SetCamera(1); 
            }; 
        _keyboardInput.Rooms.Camera3.performed += 
            (InputAction.CallbackContext cb) => {
                SetCamera(2); 
            }; 
        _keyboardInput.Rooms.Camera4.performed += 
            (InputAction.CallbackContext cb) => {
                SetCamera(3); 
            }; 
        _keyboardInput.Rooms.Camera5.performed += 
            (InputAction.CallbackContext cb) => {
                SetCamera(4); 
            }; 
        _currentCamera = 0;
        SetCamera(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    void SetCamera(int cameraNumber) {
        if (cameraNumber != _currentCamera)
        {
            _currentCamera = cameraNumber;
            foreach (var camera in cameras)
            {
                camera.SetActive(false);
            }

            cameras[_currentCamera].SetActive(true);
            
            // fall chance
            if(EventManager.Next(100) < 20) EventManager.SonEventsList[SonEvents.fall].Invoke();
        }
    }
}

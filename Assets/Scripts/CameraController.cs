using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] List<GameObject> cameras;
    public List<InputAction> actions;
    [SerializeField] float cycleTime;
    
    private int _currentCamera;
    private KeyboardInput _keyboardInput;

    // Start is called before the first frame update
    void Start() {
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
        actions[0].performed += (InputAction.CallbackContext cb) => {
            SetCamera(0); 
        };
        _currentCamera = 0;
        SetCamera(0);
        //StartCoroutine(CycleCameras());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextCamera()
    {
        _currentCamera++;
        _currentCamera%= cameras.Count;
        SetCamera(_currentCamera);
    }

    void SetCamera(int cameraNumber) {
        _currentCamera = cameraNumber;
        foreach (var camera in cameras) {
            camera.SetActive(false);
        }
        cameras[_currentCamera].SetActive(true);
    }

    IEnumerator CycleCameras()
    {
        while (true)
        {
            NextCamera();
            yield return new WaitForSeconds(cycleTime);
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SonController : MonoBehaviour
{
    // controls
    [SerializeField] List<RoomData> rooms;
    private int _currentRoom = -1;
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
        _currentRoom = -1;
    }

    void ChangeEnergy(float value)
    {
        _energy += value;
        Debug.Log(_energy);
    }

    // Start is called before the first frame update
    void Start()
    {
        GotoRoom(0);
        EventManager.SonEventsList[SonEvents.fall] += () => { ChangeEnergy(-5); };
        // input system init
        _keyboardInput = new KeyboardInput();
        _keyboardInput.Rooms.Enable();
        _keyboardInput.Rooms.Camera1.performed += 
            (InputAction.CallbackContext cb) => {
                GotoRoom(0); 
            }; 
        _keyboardInput.Rooms.Camera2.performed += 
            (InputAction.CallbackContext cb) => {
                GotoRoom(1); 
            }; 
        _keyboardInput.Rooms.Camera3.performed += 
            (InputAction.CallbackContext cb) => {
                GotoRoom(2); 
            }; 
        _keyboardInput.Rooms.Camera4.performed += 
            (InputAction.CallbackContext cb) => {
                GotoRoom(3); 
            }; 
        _keyboardInput.Rooms.Camera5.performed += 
            (InputAction.CallbackContext cb) => {
                GotoRoom(4); 
            };
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void GotoRoom(int roomNumber)
    {
        if (roomNumber != _currentRoom)
        {
            foreach (var room in rooms)
            {
                room.roomCamera.SetActive(false);
                room.hideCamera.SetActive(false);
            }
            // fall chance (not in initial room)
            if(_currentRoom != -1)
                if(EventManager.Next(100) < 20) EventManager.SonEventsList[SonEvents.fall].Invoke();
            _currentRoom = roomNumber;
            rooms[_currentRoom].roomCamera.SetActive(true);
        }
    }
    
    // void SetCamera(int cameraNumber) {
    //     if (cameraNumber != _currentCamera)
    //     {
    //         _currentCamera = cameraNumber;
    //         foreach (var camera in cameras)
    //         {
    //             camera.SetActive(false);
    //         }
    //
    //         cameras[_currentCamera].SetActive(true);
    //         
    //         // fall chance
    //         if(EventManager.Next(100) < 20) EventManager.SonEventsList[SonEvents.fall].Invoke();
    //     }
    // }
}

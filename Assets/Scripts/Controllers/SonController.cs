using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SonController : NavController
{
    // controls
    [SerializeField] List<RoomData> rooms;
    private int _currentRoom = -1;
    private KeyboardInput _keyboardInput;
    private bool _hiding;
    private Camera myCamera;
    
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
        myCamera = GetComponentInChildren<Camera>();
        endWalking += Transition;
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
        EventManager.SonEventsList[SonEvents.cameraChange] += ChangeCamera;
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

    void Transition(bool withRotation)
    {
        if(withRotation)
            GameManager.Instance.actionsUI.SetActive(true);
        else
            EventManager.SonEventsList[SonEvents.cameraTransition].Invoke();
        GameManager.Instance.roomsUI.SetActive(true);
    }

    void ChangeCamera()
    {
        myCamera.enabled = !_hiding;
        transform.rotation = _hiding
            ? rooms[_currentRoom].hideCamera.transform.rotation
            : rooms[_currentRoom].roomCamera.transform.rotation;
        //rooms[_currentRoom].roomCamera.SetActive(!_hiding);
        
        rooms[_currentRoom].hideCamera.SetActive(_hiding);
    }


    public void GotoRoom(int roomNumber)
    {
        if (!_walking && roomNumber != _currentRoom) {
            GameManager.Instance.actionsUI.SetActive(false);
            GameManager.Instance.roomsUI.SetActive(false);
            _hiding = false;
            foreach (var room in rooms)
            {
                room.roomCamera.SetActive(false);
                room.hideCamera.SetActive(false);
            }
            // fall chance (not in initial room)
            if(_currentRoom != -1)
                if(EventManager.Next(100) < 20) EventManager.SonEventsList[SonEvents.fall].Invoke();
            _currentRoom = roomNumber;
            GoTo(rooms[_currentRoom].roomCamera);
            //rooms[_currentRoom].roomCamera.SetActive(true);
            //GameManager.Instance.actionsUI.SetActive(true);
        }
    }

    void GoTo(GameObject place)
    {
        // transform.position = place.transform.position;
        // transform.rotation = place.transform.rotation;
        
        if (!_walking) {
            myCamera.enabled = true;
            StartCoroutine(walkTo(place.transform, !_hiding));
        }
    }
    
    public void Hide()
    {
        // rooms[_currentRoom].roomCamera.SetActive(false);
        // rooms[_currentRoom].hideCamera.SetActive(true);
        GameManager.Instance.actionsUI.SetActive(false);
        GameManager.Instance.roomsUI.SetActive(false);
        _hiding = true;
        GoTo(rooms[_currentRoom].hideCamera);
    }    
    
    public void Trap()
    {
        rooms[_currentRoom].trap.SetActive(true);
    } 
    
    public void Prank()
    {
        rooms[_currentRoom].prank.SetActive(true);
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

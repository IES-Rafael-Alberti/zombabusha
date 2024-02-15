using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public MotherController MotherC; //Rubus (Added MotherController)
    public GameObject Mother;
    public SonController SonC; //Rubus (Added -C to name to make the naming convention alike the other controller)
    public RawImage cameratexture;
    public GameObject actionsUI;

    private static GameManager _instance;
    public static GameManager Instance => _instance;

    public GameManager() {
        _instance = this;
    }
    
    private void Awake()
    {
        EventManager.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    
}

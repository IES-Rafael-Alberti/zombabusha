using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject Mother;
    public SonController Son;
    public RawImage cameratexture;

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

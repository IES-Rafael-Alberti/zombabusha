using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] List<GameObject> cameras;
    [SerializeField] float cycleTime;
    private int _currentCamera;

    // Start is called before the first frame update
    void Start()
    {
        _currentCamera = 0;
        SetCamera();
        StartCoroutine(CycleCameras());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void NextCamera()
    {
        _currentCamera++;
        _currentCamera%= cameras.Count;
        SetCamera();
    }

    void SetCamera()
    {
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

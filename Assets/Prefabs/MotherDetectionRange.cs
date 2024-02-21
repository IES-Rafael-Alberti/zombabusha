using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherDetectionRange : MonoBehaviour
{
    [SerializeField] private float scaleFactor = 0.1f;
    [SerializeField] private float scaleSpeed = 1f;

    private Vector3 initialScale;
    [SerializeField] private float maxRange = 5f;

    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: GameManager.Instance.MotherController.rage to access the rage bar; set max to maxRage.

        Vector3 newScale = transform.localScale;
        newScale.x += scaleFactor * Time.deltaTime * scaleSpeed;
        newScale.z += scaleFactor * Time.deltaTime * scaleSpeed;

        newScale.x = Mathf.Min(newScale.x, initialScale.x * maxRange);
        newScale.z = Mathf.Min(newScale.z, initialScale.z * maxRange);

        transform.localScale = newScale;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPointerFollowObject : MonoBehaviour
{
    [SerializeField] private Transform pointedObject;
    [SerializeField] private float followSpeed = 0.5f;

    private Vector3 offset = new Vector3(0f,-40f,0f);

    // Update is called once per frame
    void Update()
    {
        if (pointedObject != null)
        {
            Vector3 targetPosition = pointedObject.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}

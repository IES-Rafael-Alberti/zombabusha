using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrankController : MonoBehaviour
{
    [SerializeField] private float trapDuration = 20f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroySelf", trapDuration);
    }

    // Update is called once per frame
    void Update()
    {
        // TODO Interaction with Mother
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}

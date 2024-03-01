using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.tag =="red" || collision.gameObject.tag == "black" || collision.gameObject.tag == "bullseye")
        {
            Debug.Log("Collision");
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }

    }
}

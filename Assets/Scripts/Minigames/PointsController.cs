using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsController : MonoBehaviour
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

        if (collision.gameObject.tag == "red")

        {
            Debug.Log("5 points");
        }

        else if (collision.gameObject.tag == "black")

        {
            Debug.Log("1 point");
        }

        else if (collision.gameObject.tag == "bullseye")

        {
            Debug.Log("10 points");
        }

        else 
        
        {
            Debug.Log("No points");
        }

    }

}

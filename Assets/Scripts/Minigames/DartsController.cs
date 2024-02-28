using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DartsController : MonoBehaviour
{

    public GameObject dart;
    public GameObject bullseye;
    [SerializeField] private float bulletOffset;
    [SerializeField] private Vector3 bulletForce;
    [SerializeField] private Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        //camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        /* [2D Method test] 
        Vector2 mouseWorldPoint = camera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mouseWorldPoint);*/


        /* [3D Method test] 
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit)) {
            Debug.Log(raycastHit.point);
        }*/



        if (Input.GetButtonDown("Fire1"))
        {
            Shot();
            
        }

    }

    private void Shot()
    {

        GameObject bullet = Instantiate(dart, gameObject.transform);
        bullet.transform.position = new Vector3(bullseye.transform.position.x, bullseye.transform.position.y, bullseye.transform.position.z + bulletOffset);
        bullet.transform.localScale = Vector3.one * 250;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            bullet.transform.position = raycastHit.point;
        }


        bullet.GetComponent<Rigidbody>().AddForce(bulletForce, ForceMode.Impulse);


        Destroy(bullet, 3f);
    }


}

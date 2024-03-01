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
    [SerializeField] int maxAmmo;

    [SerializeField] Quaternion bulletRotation;
    private int currentAmmo;

    // Start is called before the first frame update
    void Start()
    {
        //camera = Camera.main;
        currentAmmo = maxAmmo;

        HideUI(); 
    }

    // Update is called once per frame
    void Update()
    {

        // 2D Aim Method test


        // 3D Aim Method test
        /*Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit)) {
            Debug.Log(raycastHit.point);
        }*/



        if (Input.GetButtonDown("Fire1"))
        {
            Vector2 center = new Vector2(camera.scaledPixelWidth/2, camera.scaledPixelHeight/2);
            Vector2 shotPosition = (Vector2) Input.mousePosition - center;
            shotPosition = shotPosition * 3.0f / 220f; 

            Vector3 releasePosition = camera.transform.position;
            releasePosition.z += bulletOffset;
            releasePosition.x += shotPosition.x;
            releasePosition.y += shotPosition.y;

            GameObject bullet = Instantiate(dart, releasePosition, bulletRotation);
            //bullet.transform.localScale = Vector3.one * 10;
            bullet.GetComponent<Rigidbody>().AddForce(bulletForce, ForceMode.Impulse);
            //Shot();
        }

    }

    private void Shot()
    {

        if (currentAmmo >= 1)
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



            currentAmmo--;

            //Destroy(bullet, 3f);
        }
        else 
        {
            Debug.Log("Out of ammo");
        }
        
    }

    private void HideUI()

    {
        GameObject[] UIElist = GameObject.FindGameObjectsWithTag("UIelements");
        foreach (GameObject obj in UIElist) 
        { 
            obj.SetActive(false);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darts : MonoBehaviour
{

    public GameObject dart;
    public GameObject bullseye;
    [SerializeField] private float bulletOffset;
    [SerializeField] private Vector3 bulletForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Estás pulsando click izquierdo!");
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            GameObject bullet = Instantiate(dart, gameObject.transform);
            bullet.transform.position = new Vector3(bullseye.transform.position.x, bullseye.transform.position.y, bullseye.transform.position.z + bulletOffset);
            bullet.transform.localScale = Vector3.one * 250;
            bullet.GetComponent<Rigidbody>().AddForce(bulletForce, ForceMode.Impulse);

    

            Destroy(bullet, 3f);
        }

    }
}

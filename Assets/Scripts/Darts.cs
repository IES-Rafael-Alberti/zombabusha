using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Darts : MonoBehaviour
{

    public GameObject dart;
    public float speed;
    [SerializeField] private float bulletOffset;
    [SerializeField] private Vector2 bulletForce;

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

            GameObject bullet = Instantiate(dart, transform.position + Vector3.up * bulletOffset, Quaternion.identity);
            Vector2 directedBulletForce = new Vector2(bulletForce.x, bulletForce.y);
            bullet.AddComponent<Rigidbody>();
            //bullet.GetComponent<Rigidbody>().mass = 3;
            bullet.GetComponent<Rigidbody>().AddForce(directedBulletForce, ForceMode.Impulse);

            /*bullet.AddComponent<Rigidbody>();
            bullet.GetComponent<Rigidbody>().mass = 3;
            bullet.GetComponent<Rigidbody>().AddForce(ray.direction * speed);
            bullet.AddComponent<BoxCollider>();*/

            //Destroy(bullet, 3f);
        }

    }
}

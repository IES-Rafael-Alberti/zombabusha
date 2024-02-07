using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapInstancer : MonoBehaviour
{
    public GameObject prankObject;

    public int maxObjects = 3;
    public float prankCooldown = 5f;
    private bool inCooldown = false;
    public Transform position; // TODO slight random position

    void Start()
    {
        StartCoroutine(PlacePrank());
    }

    private IEnumerator PlacePrank() // TODO Anadir a lista
    {
        int prankCount = GameObject.FindGameObjectsWithTag("Prank").Length;

        if(prankCount <= 2 || inCooldown == false)
        {
            Instantiate(prankObject, position.position, Quaternion.identity);

            inCooldown = true;
            yield return new WaitForSeconds(prankCooldown);
            inCooldown = false;
        }
    }
}

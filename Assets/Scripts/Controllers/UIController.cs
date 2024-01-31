using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    [SerializeField] private float flashTime;

    [SerializeField] private AudioSource fallSound;
    // Start is called before the first frame update
    void Start() {
        EventManager.SonEventsList[SonEvents.fall] += () => {
            StartCoroutine(SonFall());
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SonFall() {
        GameManager.Instance.cameratexture.enabled = true;
        fallSound.Play();
        yield return new WaitForSeconds(flashTime);
        GameManager.Instance.cameratexture.enabled = false;
    }
}

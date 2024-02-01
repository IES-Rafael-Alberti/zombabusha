using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class UIController : MonoBehaviour {
    [SerializeField] private float flashTime;

    [SerializeField] private AudioSource fallSound;
    
    private TextMeshProUGUI textMesh;
    private float _health;


    // Start is called before the first frame update
    void Start() {

        EventManager.SonEventsList[SonEvents.fall] += () => {
            StartCoroutine(SonFall());
        };


        textMesh = GetComponent<TextMeshProUGUI>();

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

     public int ShowHealth() 
    
    {
        textMesh.text = SonController.Instance.PrintHealth();

    }
}

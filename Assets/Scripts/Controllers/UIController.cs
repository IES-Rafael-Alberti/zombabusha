using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
    [SerializeField] private float flashTime;

    [SerializeField] private AudioSource fallSound;
    // Start is called before the first frame update

    public Image fillImage; //Rubus (Image for the RageBar)
    public static float fillAmount = 0f;

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
        IncreaseRageFill(5f); //Rubus (Fills bar completely TODO fix)
        GameManager.Instance.cameratexture.enabled = true;
        fallSound.Play();
        yield return new WaitForSeconds(flashTime);
        GameManager.Instance.cameratexture.enabled = false;
    }

    public void IncreaseRageFill(float increaseAmount) //Rubus (Function for increasing Rage)
    {
        fillAmount += increaseAmount / 100f;
        fillAmount = Mathf.Max(fillAmount, 0);
        fillImage.fillAmount = fillAmount;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private float flashTime;

    [SerializeField] private AudioSource fallSound;
    // Start is called before the first frame update

    public Image fillImageM; //Rubus (Image for the RageBar)

    public Image fillImageS; //David (added M/S to distinguish one fill from another)

    public static float fillAmountM = 0f;

    public static float fillAmountS = 1f;

    void Start()
    {
        EventManager.SonEventsList[SonEvents.fall] += () => {
            StartCoroutine(SonFall());
        };
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SonFall()
    {
        IncreaseRageFill(5f); //Rubus (Fills bar completely TODO fix)
        DecreaseNerveFill(5f);
        GameManager.Instance.cameratexture.enabled = true;
        fallSound.Play();
        yield return new WaitForSeconds(flashTime);
        GameManager.Instance.cameratexture.enabled = false;
    }

    public void IncreaseRageFill(float increaseAmount) //Rubus (Function for increasing Rage)
    {
        fillAmountM += increaseAmount / 100f;
        fillAmountM = Mathf.Max(fillAmountM, 0);
        fillImageM.fillAmount = fillAmountM;
    }

    public void DecreaseNerveFill(float decreaseAmount) //David (Tried to replicate Rage Function with Son Nerve Bar)
    {
        fillAmountS -= decreaseAmount / 100f;
        fillAmountS = Mathf.Max(fillAmountS, 0);
        fillImageS.fillAmount = fillAmountS;
    }

}

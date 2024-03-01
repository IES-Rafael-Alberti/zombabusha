using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private float flashTime;
    [SerializeField] private AudioSource fallSound;
    
    [SerializeField] private GameObject _babusha;
    [SerializeField] private Image _fade;
    [SerializeField] private float _fadeSpeed = 1.0f;
    [SerializeField] private float _scaleEnd = 5.0f;
    [SerializeField] private float _scaleStep = 5f;
    [SerializeField] private float _rotateStep = -180f;
    [SerializeField] private float _scaleInit = 1.0f;
    [SerializeField] private AnimationCurve curve = 
        new AnimationCurve(new Keyframe(0, 1),
                            new Keyframe(0.5f, 0.5f, -1.5f, -1.5f), 
                            new Keyframe(1, 0));

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
        
        EventManager.SonEventsList[SonEvents.cameraTransition] += () => {
            StartCoroutine(BabushaTrans());
        };
    }
    
    // transition between cams
    IEnumerator BabushaTrans()
    {
        float alpha = 0f;

        Color fadeColor = _fade.color;
        fadeColor.a = alpha;
        _fade.color = fadeColor;
        
        _fade.enabled = true;
        while (alpha <= 1.0f)
        {
            alpha += _fadeSpeed * Time.deltaTime;
            fadeColor.a = alpha;
            _fade.color = fadeColor;
            yield return true;
        }
        EventManager.SonEventsList[SonEvents.cameraChange].Invoke();
        _fade.enabled = false;
        
        _babusha.SetActive(true);
        Image babushaImage = _babusha.GetComponent<Image>();
        fadeColor = babushaImage.color;
        fadeColor.a = 1.0f;
        babushaImage.color = fadeColor;
        float scale = 0f;
        while (scale < _scaleEnd)
        {
            scale += _scaleStep * Time.deltaTime;
            _babusha.transform.localScale = Vector3.one * (_scaleInit + curve.Evaluate(scale));
            //_babusha.transform.Rotate(Vector3.forward, _rotateStep * Time.deltaTime);
            yield return true;
        }

        while (alpha > 0f)
        {
            alpha -= _fadeSpeed * Time.deltaTime;
            fadeColor.a = alpha;
            babushaImage.color = fadeColor;
            yield return true;
        }
        
        _babusha.SetActive(false);
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

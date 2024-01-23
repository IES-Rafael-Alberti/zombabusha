using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController2 : MonoBehaviour
{
    [SerializeField] private string IntroState = "Idle";
    private Animator _animator;
    //private bool _intro;
    public bool scream;
    public bool joy;
    private bool waitforscream;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play(IntroState);
        //_intro = true;
        waitforscream = false;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            //_intro = false;
            Debug.Log("QuietoParao");
            StartCoroutine(Scream());
            waitforscream = true;
            //StartCoroutine(Joy());

            scream = true;
            joy = false;

        }
        if (scream)
        {
            waitforscream = false;
            StopCoroutine(Scream());
            StartCoroutine(Joy());
            Debug.Log("Gritando!!");
            scream = false;
            joy = true;
        }
        else if (joy)
        {

            Debug.Log("Yupi");
            StopCoroutine(Joy());

        }

    }



    IEnumerator Scream() 
    
    {
        
        yield return new WaitForSeconds(2f);
        _animator.Play("Scream");
        //scream = true;
        //StartCoroutine(Joy());


    }

    IEnumerator Joy()

    {

        yield return new WaitForSeconds(10f);
        _animator.Play("JoyJump");
        //joy = true;
        //StopCoroutine(Joy());

    }


}

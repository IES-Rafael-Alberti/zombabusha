using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
    private string input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadStringInput(string s)
    {
        input = s;
        char lastChar = s[s.Length -1]; //TODO Check if the string is longer than 0.
        if (lastChar == ' ')
            {
                //TODO Call to event "NextWord".
            }
        Debug.Log(lastChar);
    }
}

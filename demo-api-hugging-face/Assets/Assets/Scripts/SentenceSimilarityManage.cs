using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SentenceSimilarityManage : MonoBehaviour
{
    /// <summary>
    /// The Robot Action List
    /// </summary>
    [System.Serializable]
    public struct Actions
    {
        public string sentence;
        public string verb;
        public string noun;
    }

    public TMP_Text letters;
    private State state;

    [Header("Text Brain")]
    public Brain Brain;

    [Header("Text list of actions")]
    public List<Actions> actionsList;

    [HideInInspector]
    public List<string> sentences; // Test list of sentences (actions)
    public string[] sentencesArray;

    [HideInInspector]
    public float maxScore;
    public int maxScoreIndex;

    /// <summary>
    /// Enum of the different possible states of the text
    /// </summary>
    private enum State
    {
        Idle,
        Exit, // Salir del escondite
        Hide, // Esconderse
        MoveTo // Cambiar de habitaci�n (living room, boy room, girl room, bathroom, big room
    }

    /// <summary>
    /// Utility function: Given the results of HuggingFaceAPI, select the State with the highest score
    /// </summary>
    /// <param name="maxValue">Value of the option with the highest score</param>
    /// <param name="maxIndex">Index of the option with the highest score</param>
    public void Utility(float maxScore, int maxScoreIndex)
    {
        // First we check that the score is > of 0.2, otherwise we let our agent perplexed;
        // This way we can handle strange input text (for instance if we write "Go see the dog!" the agent will be puzzled).
        if (maxScore < 0.20f)
        {
            state = State.Idle;
        }
        else
        {
            // Get the verb and noun (if there is one)
            //goalObject = GameObject.Find(actionsList[maxScoreIndex].noun);

            string verb = actionsList[maxScoreIndex].verb;

            // Set the Text State == verb
            state = (State)System.Enum.Parse(typeof(State), verb, true);
        }
    }

    private void Awake()
    {
        // Set the State to Idle
        state = State.Idle;

        // Take all the possible actions in actionsList
        foreach (SentenceSimilarityManage.Actions actions in actionsList)
        {
            sentences.Add(actions.sentence);
        }
        sentencesArray = sentences.ToArray();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Here's the State Machine, where given its current state, the agent will act accordingly
        switch (state)
        {
            default:
            case State.Idle:
                break;

            case State.Exit:
                letters.text = "Exit";
                state = State.Idle;
                break;

            case State.Hide:
                letters.text = "Hide";
                state = State.Idle;
                break;

            case State.MoveTo:
                letters.text = "MoveTo";
                state = State.Idle;
                break;


        }
    }
}

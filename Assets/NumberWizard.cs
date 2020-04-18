using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    int max = 1000;
    int min = 0;
    int guess = 0;
    bool winConditionMet = false;
    bool inputReceived = false;
    readonly float pauseWizard = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        guess = Random.Range(min, max + 1);
        StartCoroutine(SpeakWizard());

        Debug.Log("and thats the number wizard!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up key was pressed.");
            inputReceived = true;
            min = guess;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down key was pressed.");
            inputReceived = true;
            max = guess;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Yay I guessed correctly!");
            inputReceived = true;
            winConditionMet = true;
        }

        inputReceived = false;
    }

    IEnumerator SpeakWizard()
    {
        Debug.Log("Welcome to number wizard.");
        yield return new WaitForSeconds(pauseWizard);
        Debug.Log($"Pick a number between {min} and {max}");
        yield return new WaitForSeconds(pauseWizard);
        Debug.Log("Don't tell me your number! Unless I guess correctly...");
        yield return new WaitForSeconds(pauseWizard);
        GuessAnswer();
        yield return new WaitUntil(() => inputReceived);
        while (!winConditionMet)
        {
            GuessAnswer();
            yield return new WaitUntil(() => inputReceived);
        }
    }

    void GuessAnswer()
    {
        Debug.Log($"Is your number higher or lower than {updateGuessValue()}?" +
            $"Press {KeyCode.UpArrow} for higher and {KeyCode.DownArrow} for lower." +
            $"If it is correct press {KeyCode.Return}");
    }

    int updateGuessValue()
    {
        guess = Random.Range(min, max + 1);
        return guess;
    }
}

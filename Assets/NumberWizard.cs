using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour
{
    int highestNumber = 1000;
    int lowestNumber = 0;
    int guess = 500;

    float pauseWizard = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpeakWizard());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Up key was pressed.");
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Down key was pressed.");
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Return key was pressed.");
        }
    }

    IEnumerator SpeakWizard()
    {
        Debug.Log("Welcome to number wizard.");
        yield return new WaitForSeconds(pauseWizard);
        Debug.Log($"Pick a number between {lowestNumber} and {highestNumber}");
        yield return new WaitForSeconds(pauseWizard);
        Debug.Log("Don't tell me your number! Unless I guess correctly...");
        yield return new WaitForSeconds(pauseWizard);
        Debug.Log($"Is your number higher or lower than {guess}?" +
            $"Press {KeyCode.UpArrow} for higher and {KeyCode.DownArrow} for lower." +
            $"If it is correct press {KeyCode.Return}");
        yield return new WaitForSeconds(pauseWizard);
    }
}

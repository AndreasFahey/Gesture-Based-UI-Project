using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;


public class BloonMoveSpeechRecognition : MonoBehaviour
{
   
    // Variables
    public string[] keywords = new string[] { "up", "down", "left", "right"};
    public ConfidenceLevel confidence = ConfidenceLevel.Medium;
    public float speed = 1;

    public Text results;
    public Image Bloon;

    protected PhraseRecognizer recognizer;
    protected string word = "right";

    // Start
    private void Start()
    {
        if (keywords != null)
        {

            recognizer = new KeywordRecognizer(keywords, confidence);
            recognizer.OnPhraseRecognized += Recognizer_OnPhraseRecognized;
            recognizer.Start();
        }
    }

    // Display Text of what direction Bloon is going from voice command
    private void Recognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        word = args.text;
        results.text = "You Moved the Bloon: <b>" + word + "</b>";
    }

    // Update
    private void Update()
    {
        var x = Bloon.transform.position.x;
        var y = Bloon.transform.position.y;

        switch (word)
        {
            case "up":
                y += speed;
                break;
            case "down":
                y -= speed;
                break;
            case "left":
                x -= speed;
                break;
            case "right":
                x += speed;
                break;
        }

        Bloon.transform.position = new Vector3(x, y, 0);
    }

    // Quit the Application
    private void OnApplicationQuit()
    {
        if (recognizer != null && recognizer.IsRunning)
        {
            recognizer.OnPhraseRecognized -= Recognizer_OnPhraseRecognized;
            recognizer.Stop();
        }
    }
}
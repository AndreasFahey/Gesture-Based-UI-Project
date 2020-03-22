using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour 
{
    public float difficulty = 0.5f;
    public float difficultyIncreaseSpeed = 0.01f;
    public Transform startPosition;
    public GameObject bloonGreen;

    // Timers for waves
    private float bloonTimer = 0f;
    private float nextBloon = 1f;

    // Bloon Limits
    public int bloonsPerWave = 20;
    private int bloonsCount = 1;

    // Waves Timer
    public float wavesTimer = 0f;
    public float nextWave = 20f;

    // Update is called once per frame
    void Update()
    {
        // Send The Bloons !!
        if(bloonTimer < Time.time && wavesTimer < Time.time)
        {
            bloonsCount++;
            difficulty += difficultyIncreaseSpeed;
            bloonTimer = Time.time + nextBloon;
 
                var bloon =  Instantiate(bloonGreen, startPosition.position, bloonGreen.transform.rotation);
                bloon.GetComponent<Bloon>().health += (int)System.Math.Round(difficulty);
                bloon.GetComponent<Bloon>().speed += (int)System.Math.Round(difficulty);
        }

        // Make the Waves
        if (bloonsCount % bloonsPerWave == 0 && wavesTimer < Time.time)
        {
            wavesTimer = nextWave + Time.time;
        }

    }
}